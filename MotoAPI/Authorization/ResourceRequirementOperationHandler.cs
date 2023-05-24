using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using MotoAPI.Entitites;

namespace MotoAPI.Authorization;

public class ResourceRequirementOperationHandler : AuthorizationHandler<ResourceOperationRequirement, Moto>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        ResourceOperationRequirement requirement,
        Moto moto)
    {
        if (requirement.ResourceOperation == ResourceOperation.Read ||
            requirement.ResourceOperation == ResourceOperation.Create)
        {
            context.Succeed((requirement));
        }

        var userid = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        if (moto.CreatedById == int.Parse(userid))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}