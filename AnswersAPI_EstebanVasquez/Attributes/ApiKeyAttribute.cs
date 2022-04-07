using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;

namespace AnswersAPI_EstebanVasquez.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.All)]
    public sealed class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKey = "ApiKey";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKey, out var ApiOutput))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "No se ha incluído una API Key"
                };
                return;
            }
            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apikey = appSettings.GetValue<string>(ApiKey);
            if (!apikey.Equals(ApiOutput))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "La API Key suministrada es incorrecta."
                };
                return;
            }
            await next();
        }
    }
}
