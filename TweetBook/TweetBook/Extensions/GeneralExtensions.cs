using System.Linq;
using Microsoft.AspNetCore.Http;

namespace TweetBook.Extensions
{
    public static class GeneralExtensions
    {
        public static string GetUserId(this HttpContext context)
        {
            if (context.User == null)
            {
                return string.Empty;
            }
            
            return context.User.Claims.Single(x => x.Type == "id").Value;
        }
    }
}