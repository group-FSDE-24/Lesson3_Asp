namespace Lesson3_ASP_Net6.Middlewares;

public class LogMiddleware
{
    public RequestDelegate? Next { get; set; }

    public LogMiddleware(RequestDelegate request)
    {
        Next = request;
    }

    public async Task Invoke(HttpContext context)
    {
        Console.WriteLine("Log middleware-i ise basladi.....");

        await Next?.Invoke(context);

        Console.WriteLine("Log middleware-i isi sonlandi.....");
    }
}
