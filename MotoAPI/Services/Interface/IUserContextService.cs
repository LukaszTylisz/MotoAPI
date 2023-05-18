using System.Security.Claims;

namespace MotoAPI.Services.Interface;

public interface IUserContextService
{
    ClaimsPrincipal User { get; }
    int? GetUserId { get; }
}