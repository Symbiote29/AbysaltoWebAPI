using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AbysaltoWebAPI.Security
{
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string HEADER_NAME = "Authorization";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(HEADER_NAME, out var extractedApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var apiKey = configuration["ApiKey"];
            var providedKey = extractedApiKey.ToString().Replace("ApiKey", "");

            if (!string.Equals(apiKey, providedKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
