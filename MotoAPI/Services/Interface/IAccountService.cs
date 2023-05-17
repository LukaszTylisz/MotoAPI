using MotoAPI.Models;

namespace MotoAPI.Services;

public interface IAccountService
{
    void RegisterUser(RegisterUserDto dto);
    string GenerateJwt(LoginDto dto);
}