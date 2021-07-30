using NorthwindApi.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace NorthwindApi.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger<ErrorResponse> logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    { 
                        // logger.LogError($"{contextFeature.Error} {contextFeature.Error.Message}");

                        await context.Response.WriteAsync(new ErrorResponse()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = $"{context.Request.Method} Request Failed"
                            // https://stackoverflow.com/questions/18248547/get-controller-and-action-name-from-within-controller
                            // https://stackoverflow.com/questions/42582758/asp-net-core-middleware-vs-filters/42583583#42583583
                        }.ToString());
                    }
                });
            });
        }
    }
}
