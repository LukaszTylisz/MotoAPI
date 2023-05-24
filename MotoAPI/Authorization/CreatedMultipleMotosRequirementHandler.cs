using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using MotoAPI.Entitites;

namespace MotoAPI.Authorization;

public class CreatedMultipleMotosRequirementHandler : AuthorizationHandler<CreatedMultipleMotosRequirement>
{
    private readonly MotoDbContext _context;

    public CreatedMultipleMotosRequirementHandler(MotoDbContext context)
    {
        _context = context;
    }
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CreatedMultipleMotosRequirement requirement)
    {
        var userId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

        var createdMotosCount = _context
            .Motos
            .Count(m => m.CreatedById == userId);

        if (createdMotosCount >= requirement.MinimumMotosCreated)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}