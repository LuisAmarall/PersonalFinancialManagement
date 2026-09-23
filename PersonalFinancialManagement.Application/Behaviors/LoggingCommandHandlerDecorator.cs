using System.Diagnostics;
using Microsoft.Extensions.Logging;
using PersonalFinancialManagement.Application.Abstractions;

namespace PersonalFinancialManagement.Application.Behaviors;

public class LoggingCommandHandlerDecorator<TCommand, TResult> : ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
    private readonly ICommandHandler<TCommand, TResult> _inner;
    private readonly ILogger<LoggingCommandHandlerDecorator<TCommand, TResult>> _logger;

    public LoggingCommandHandlerDecorator(ICommandHandler<TCommand, TResult> inner, 
        ILogger<LoggingCommandHandlerDecorator<TCommand, TResult>> logger)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<TResult> HandlerAsync(TCommand command, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Starting {CommandType} {@Command}", typeof(TCommand).Name, command);
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var result = await _inner.HandlerAsync(command, cancellationToken);

            _logger.LogInformation("{CommandType} concluído em {ElapsedMs}ms. Result: {@Result}",
                typeof(TCommand).Name, stopwatch.ElapsedMilliseconds, result);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro em {CommandType}", typeof(TCommand).Name);
            throw;
        }
    }
}