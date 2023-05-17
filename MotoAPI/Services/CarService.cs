using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MotoAPI.Entitites;
using MotoAPI.Exceptions;
using MotoAPI.Models;
using MotoAPI.Services.Interface;

namespace MotoAPI.Services;

public class CarService : ICarService
{
    private readonly MotoDbContext _context;
    private readonly IMapper _mapper;

    public CarService(MotoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public int Create(int motoId, CreateCarDto dto)
    {
        var moto = GetMotoById(motoId);
        var carEntity = _mapper.Map<Car>(dto);

        carEntity.MotoId = motoId;

        _context.Cars.Add(carEntity);
        _context.SaveChanges();

        return carEntity.Id;
    }

    public CarDto GetById(int motoId, int carId)
    {
        var moto = GetMotoById(motoId);

        var car = _context.Cars.FirstOrDefault(c => c.Id == carId);
        if (car is null || car.MotoId != motoId)
            throw new NotFoundException("Car not found");

        var carDto = _mapper.Map<CarDto>(car);
        return carDto;
    }

    public List<CarDto> GetAll(int motoId)
    {
        var moto = GetMotoById(motoId);
        var carDtos = _mapper.Map<List<CarDto>>(moto.Cars);

        return carDtos;
    }

    public void RemoveAll(int motoId)
    {
        var moto = GetMotoById(motoId);
        
        _context.RemoveRange(moto.Cars);
        _context.SaveChanges();
    }

    private Moto GetMotoById(int motoId)
    {
        var moto = _context
            .Motos
            .Include(r => r.Cars)
            .FirstOrDefault(r => r.Id == motoId);

        if (moto is null)
            throw new NotFoundException("MotoShowroom not found");

        return moto;
    }
}