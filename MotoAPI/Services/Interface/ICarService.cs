using MotoAPI.Models;

namespace MotoAPI.Services.Interface;

public interface ICarService
{
    int Create(int motoId, CreateCarDto dto);
    CarDto GetById(int motoId, int carId);
    List<CarDto> GetAll(int motoId);
    void RemoveAll(int motoId);
}