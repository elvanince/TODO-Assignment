using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TODOBackend.Middleware
{
    /// <summary>
    /// OPTIONS HTTP-method handler
    /// </summary>
    /// <remarks>
    /// See:     https://github.com/drwatson1/AspNet-Core-REST-Service/wiki#cross-origin-resource-sharing-cors-and-preflight-requests
    /// </remarks>
    public class OptionsVerbMiddleware
    {
        RequestDelegate Next { get; }

        public OptionsVerbMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == "OPTIONS")
            {
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.Headers.Add("Access-Control-Allow-Methods", "*");
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                return Task.CompletedTask;
            }
            return Next.Invoke(context);
        }
    }
}
