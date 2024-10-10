using System.Security.Claims;

namespace ProjWork.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string RetriveEmailFromPrinciple(this ClaimsPrincipal user) { 
            return user?.Claims?.FirstOrDefault(x=>x.Type==ClaimTypes.Email)?.Value;
        }
    }
}
