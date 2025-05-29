using System.Security.Claims;

namespace Stock.Stock.Application.Helper
{
    public static class TokenHelper
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user?.FindFirst("uid")?.Value;
        }

        public static string GetUserRole(this ClaimsPrincipal user)
        {
            return user?.FindFirst(ClaimTypes.Role)?.Value;
        }
    }
}
