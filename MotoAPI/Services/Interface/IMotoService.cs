using MotoAPI.Models;

namespace MotoAPI.Services.Interface;

public interface IMotoService
{
    MotoDto GetById(int id);
    IEnumerable<MotoDto> GetAll();
    int Create(CreateMotoDto dto);
    void Delete(int id);
    void Update(int id, UpdateMotoDto dto);
}