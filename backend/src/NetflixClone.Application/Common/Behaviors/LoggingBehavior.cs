using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace NetflixClone.Application.Common.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var uniqueId = Guid.NewGuid().ToString();

        _logger.LogInformation("[Start] {RequestName} ({UniqueId})", requestName, uniqueId);

        var timer = new Stopwatch();
        timer.Start();

        try
        {
            var response = await next();
            timer.Stop();

            _logger.LogInformation("[End] {RequestName} ({UniqueId}) completed in {Elapsed}ms",
                requestName, uniqueId, timer.ElapsedMilliseconds);

            return response;
        }
        catch (Exception ex)
        {
            timer.Stop();
            _logger.LogError(ex, "[Error] {RequestName} ({UniqueId}) failed in {Elapsed}ms",
                requestName, uniqueId, timer.ElapsedMilliseconds);
            throw;
        }
    }
} 