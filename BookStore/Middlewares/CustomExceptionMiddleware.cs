using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;

namespace BookStoreWebApi.Middlewares
{
    public class CustomExceptionMiddlewares
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddlewares(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew(); //Request'i aldık response'u başlattığımız zaman.
            try
            {
                string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
                await _next(context); //Bir sonraki middleware'i çağırır.
                watch.Stop();//Hata olmazsa response döndük ve buraya dönerek zaman sayacını durdurduk.
                message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + "ms";

            }
            catch (Exception ex) 
            {
                watch.Stop();//Bir sonraki MiddleWare'da (endpointde) hata fırlarsa burada tutulur. Yukarıdaki watch.stop'a geçmeden buraya gelir, zamanı burada durdurur.
                await HandleException(context, ex, watch);
            }

        }
        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "[Error] HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message: " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds + "ms";
            
            var result = JsonConvert.SerializeObject(new{error=message},Formatting.None);
            return context.Response.WriteAsync(result);

        }
    }
    public static class CustomExceptionMiddlewareExtension
    {
		public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<CustomExceptionMiddlewares>();
		}
    }
}