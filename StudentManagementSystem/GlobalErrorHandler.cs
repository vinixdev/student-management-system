using Contracts;
using Microsoft.AspNetCore.Diagnostics;

namespace StudentManagementSystem;

public class GlobalErrorHandler: IExceptionHandler
{
    private readonly ILoggerManager _logger;

    public GlobalErrorHandler(ILoggerManager logger) => _logger = logger;
    
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}