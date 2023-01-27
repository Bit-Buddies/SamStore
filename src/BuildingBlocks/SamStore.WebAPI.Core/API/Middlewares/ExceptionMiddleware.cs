using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SamStore.WebAPI.Core.API.Models;
using System.Net;

namespace SamStore.WebAPI.Core.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (UnauthorizedAccessException exception)
            {
                await HandleExceptionAsync(httpContext, exception, HttpStatusCode.Unauthorized);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception, HttpStatusCode.InternalServerError);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception, HttpStatusCode statusCode)
        {
            ResponseResult errorResponse;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                errorResponse = new ResponseResult(statusCode.ToString(), (int)statusCode);
                string inner = exception.InnerException != null ? $"- Inner : {exception.InnerException}" : "";
                errorResponse.AddError($"{exception.Message} {inner}");
            }
            else
            {
                errorResponse = new ResponseResult(statusCode.ToString(), (int)statusCode);
                errorResponse.AddError($"{exception.Message}");
            }

            httpContext.Response.StatusCode = (int)statusCode;

            var result = JsonConvert.SerializeObject(errorResponse);
            httpContext.Response.ContentType = "application/json";

            return httpContext.Response.WriteAsync(result);
        }
    }
}
