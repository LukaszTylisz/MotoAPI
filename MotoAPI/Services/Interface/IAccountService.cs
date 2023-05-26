using MotoAPI.Models;

namespace MotoAPI.Services.Interface;

public interface IAccountService
{
    void RegisterUser(RegisterUserDto dto);
    string GenerateJwt(LoginDto dto);
}