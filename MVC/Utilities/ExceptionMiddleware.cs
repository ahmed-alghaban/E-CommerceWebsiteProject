using System.Net;
using E_CommerceWebsiteProject.MVC.Utilities.Exceptions;
using Newtonsoft.Json;

namespace E_CommerceWebsiteProject.MVC.Utilities
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
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            ApiResponse<object> response;
            int statusCode;

            switch (exception)
            {
                case NotFoundException _:
                    statusCode = (int)HttpStatusCode.NotFound;
                    response = new ApiResponse<object>
                    {
                        IsSuccess = false,
                        Message = exception.Message,
                        Data = null
                    };
                    break;

                case ValidationException ve:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    response = new ApiResponse<object>
                    {
                        IsSuccess = false,
                        Message = ve.Message,
                        Data = ve.Errors
                    };
                    break;

                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    response = new ApiResponse<object>
                    {
                        IsSuccess = false,
                        Message = exception.Message,
                        Data = null
                    };
                    break;
            }

            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}