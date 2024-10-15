
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EFCoreDatabaseFirstApproach.Models
{
    public class GlobalExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                ProblemDetails problemDetails = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Detail=ex.Message,
                    Type="application/json"
                };

                await context.Response.WriteAsJsonAsync<ProblemDetails>(problemDetails);
            }
        }
    }
}
