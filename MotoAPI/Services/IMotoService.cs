using MotoAPI.Models;

namespace MotoAPI.Services;

public interface IMotoService
{
    MotoDto GetById(int id);
    IEnumerable<MotoDto> GetAll();
    int Create(CreateMotoDto dto);
    bool Delete(int id);
    bool Update(int id, UpdateMotoDto dto);
}