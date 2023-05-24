using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MotoAPI.Authorization;

public class MinimumAgeRequirementHandler : AuthorizationHandler<MinimumAgeRequirement>
{
    private readonly ILogger<MinimumAgeRequirementHandler> _logger;

    public MinimumAgeRequirementHandler(ILogger<MinimumAgeRequirementHandler> logger)
    {
        _logger = logger;
    }
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
    {
        var dateOfBirth = DateTime.Parse(context.User.FindFirst(c => c.Type == "DateOfBirth")!.Value);

        var userEmail = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        _logger.LogInformation("User: {UserEmail} with date of birth: [{DateOfBirth}]", userEmail, dateOfBirth);

        if (dateOfBirth.AddYears(requirement.MinimumAge) <= DateTime.Today)
        {
            _logger.LogInformation("Authorization succeed");
            context.Succeed(requirement);
        }
        else
        {
            _logger.LogInformation("Authorization failed");
        }

        return Task.CompletedTask;
    }
}