using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MotoAPI.Authorization;
using MotoAPI.Entitites;
using MotoAPI.Exceptions;
using MotoAPI.Models;
using MotoAPI.Services.Interface;

namespace MotoAPI.Services;

public class MotoService : IMotoService
{
    private readonly MotoDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<MotoService> _logger;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserContextService _userContextService;

    public MotoService(MotoDbContext dbContext, IMapper mapper, ILogger<MotoService> logger,
        IAuthorizationService authorizationService, IUserContextService userContextService)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
        _authorizationService = authorizationService;
        _userContextService = userContextService;
    }
    
    public int Create(CreateMotoDto dto)
    {
        var moto = _mapper.Map<Moto>(dto);
        moto.CreatedById = _userContextService.GetUserId;
        _dbContext.Motos.Add(moto);
        _dbContext.SaveChanges();

        return moto.Id;
    }

    public void Update(int id, UpdateMotoDto dto)
    {
        var moto = _dbContext
            .Motos
            .FirstOrDefault(m => m.Id == id);

        if (moto is null)
            throw new NotFoundException("MotoShowroom not found");

        var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, moto,
                new ResourceOperationRequirement(ResourceOperation.Update))
            .Result;

        if (!authorizationResult.Succeeded)
        {
            throw new ForbidException();
        }
        
        moto.Name = dto.Name;
        moto.Description = dto.Description;
        moto.HasService = dto.HasDelivery;

        _dbContext.SaveChanges();
    }

    public void Delete(int id )
    {
        _logger.LogWarning($"MotoShowroom with id: {id} DELETE action invoked");

        var moto = _dbContext
            .Motos
            .FirstOrDefault(m => m.Id == id);

        if (moto is null)
            throw new NotFoundException("MotoShowroom not found");

        var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, moto,
                new ResourceOperationRequirement(ResourceOperation.Delete))
            .Result;
        
        if(!authorizationResult.Succeeded)
        {
            throw new ForbidException();
        }

        _dbContext.Motos.Remove(moto);
        _dbContext.SaveChanges();
    }

    public MotoDto GetById(int id)
    {
        var moto = _dbContext
            .Motos
            .Include(m => m.Address)
            .Include(m => m.Cars)
            .FirstOrDefault(m => m.Id == id);

        if (moto is null)
            throw new NotFoundException("MotoShowroom not found");

        var result = _mapper.Map<MotoDto>(moto);

        return result;
    }

    public IEnumerable<MotoDto> GetAll()
    {
        var motos = _dbContext
            .Motos
            .Include(m => m.Address)
            .Include(m => m.Cars)
            .ToList();

        var motosDtos = _mapper.Map<List<MotoDto>>(motos);

        return motosDtos;
    }
}