using System.Text;

namespace ApiGateway.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var request = context.Request;

        var log = new StringBuilder();

        log.AppendLine("-------- API REQUEST --------");
        log.AppendLine($"Time: {DateTime.Now}");
        log.AppendLine($"Method: {request.Method}");
        log.AppendLine($"Path: {request.Path}");
        log.AppendLine($"Query: {request.QueryString}");
        log.AppendLine($"IP: {context.Connection.RemoteIpAddress}");

        await _next(context);

        log.AppendLine($"Response Status: {context.Response.StatusCode}");
        log.AppendLine("-----------------------------\n");

        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Log");

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        var filePath = Path.Combine(folderPath, "Logfile.txt");

        File.AppendAllText(filePath, log.ToString());
    }
}