using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Identity;

public sealed class ScopeRequirement : IAuthorizationRequirement
{
    public ScopeRequirement()
    {
    }
}
