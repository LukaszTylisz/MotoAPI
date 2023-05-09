using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoAPI.Entitites;
using MotoAPI.Models;

namespace MotoAPI.Controllers;

[Route("api/moto")]
public class MotoController : ControllerBase
{
    private readonly MotoDbContext _dbContext;
    private readonly IMapper _mapper;

    public MotoController(MotoDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult CreateMoto([FromBody] CreateMotoDto dto)
    {
        
    }
    
    [HttpGet]
    public ActionResult<MotoDto> GetAll()
    {
        var motos = _dbContext
            .Motos
            .Include(m => m.Address)
            .Include(m => m.Cars)
            .ToList();

        var motosDtos = _mapper.Map<List<MotoDto>>(motos);
            
        return Ok(motosDtos);
    }

    [HttpGet("{id}")]
    public ActionResult<MotoDto> Get([FromRoute] int id)
    {
        var moto = _dbContext
            .Motos
            .Include(m => m.Address)
            .Include(m => m.Cars)
            .FirstOrDefault(m => m.Id == id);

        if (moto is null)
        {
            return NotFound();
        }

        var motoDto = _mapper.Map<MotoDto>(moto);
        return Ok(motoDto);
    }
}