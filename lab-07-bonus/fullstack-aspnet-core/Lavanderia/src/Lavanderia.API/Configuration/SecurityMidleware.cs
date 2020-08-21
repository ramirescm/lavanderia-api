using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Lavanderia.API.Configuration
{
    public class SecurityMidleware
    {
        private readonly RequestDelegate _next;
        public SecurityMidleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            // https://rodolfofadino.com.br/http-upgrade-insecure-requests-com-asp-net-core-32851a55b1f5
            // para validar https://securityheaders.com/
            // https://cheatsheetseries.owasp.org/
            // configurar de acordo com o ambiente
            if (context.Response.Headers.ContainsKey("X-Powered-By"))
            {
                context.Response.Headers.Remove("X-Powered-By");
            }

            if (context.Response.Headers.ContainsKey("Server"))
            {
                context.Response.Headers.Remove("Server");
            }

            context.Response.Headers.Add("X-Frame-Options", "sameorigin");
            context.Response.Headers.Add("Referrer-Policy", "no-referrer");
            context.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", "none");
            context.Response.Headers.Add("Content-Security-Policy", "upgrade-insecure-requests;");
            context.Response.Headers.Add("Feature-Policy", "accelerometer 'none'; camera 'none'; geolocation 'none'; gyroscope 'none'; magnetometer 'none'; microphone 'none'; payment 'none'; usb 'none'");
            
            await _next(context);
        }
    }

        public static class SecurityMiddlewareExtensions
        {
            public static IApplicationBuilder UseSecurityMidleware(this IApplicationBuilder builder) => builder.UseMiddleware<SecurityMidleware>();
        }
}
