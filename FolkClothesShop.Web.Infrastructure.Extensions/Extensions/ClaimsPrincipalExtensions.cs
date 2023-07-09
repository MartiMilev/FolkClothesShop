using System.Security.Claims;

namespace FolkClothesShop.Web.Infrastructure.Extensions.Extensions

{

    public static class ClaimsPrincipalExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}