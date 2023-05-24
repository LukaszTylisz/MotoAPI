using Microsoft.AspNetCore.Authorization;

namespace MotoAPI.Authorization;

public class CreatedMultipleMotosRequirement : IAuthorizationRequirement
{

    public CreatedMultipleMotosRequirement(int minimumMotosCreated)
    {
        MinimumMotosCreated = minimumMotosCreated;
    }
    
    public int MinimumMotosCreated { get; }
}