using System.Security.Claims;
using MotoAPI.Models;

namespace MotoAPI.Services.Interface;

public interface IMotoService
{
    MotoDto GetById(int id);
    PageResult<MotoDto> GetAll(MotoQuery query);
    int Create(CreateMotoDto dto);
    void Delete(int id);
    void Update(int id, UpdateMotoDto dto);
}