using Lesson3_ASP_Net6.Middlewares;

namespace Lesson3_ASP_Net6.Extentions;

public static class MiddlewareExtentions
{
    public static IApplicationBuilder UseMiddlewareExtentions(this IApplicationBuilder application)
    {
        application.UseStaticFiles();
        application.UseRouting();
        application.UseAuthorization();
        application.UseMiddleware<LogMiddleware>();

        return application;
    }

}
