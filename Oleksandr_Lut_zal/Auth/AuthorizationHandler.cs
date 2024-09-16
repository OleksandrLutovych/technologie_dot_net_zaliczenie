using Microsoft.AspNetCore.Authorization;
using Oleksandr_Lut_zal.Models;
using System.Security.Claims;

namespace Oleksandr_Lut_zal.Auth
{
    public class AuthorizationHandler : AuthorizationHandler<IsOwnerRequirement, ShoppingPositionList>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsOwnerRequirement requirement, ShoppingPositionList resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (resource.ownerId == userId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    public class IsOwnerRequirement : IAuthorizationRequirement { }
   
}
