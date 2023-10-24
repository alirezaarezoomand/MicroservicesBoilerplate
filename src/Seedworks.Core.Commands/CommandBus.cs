using Microsoft.Extensions.DependencyInjection;

namespace Seedworks.Core.Commands;

public class CommandBus : ICommandBus
{
    private readonly IServiceProvider _serviceProvider;
    public CommandBus(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : ICommand
    {
        var handler = _serviceProvider.GetService<ICommandHandler<TCommand>>();
        var unitOfWork = _serviceProvider.GetRequiredService<IUnitOfWork>();

        if (handler == null)
        {
            throw new InvalidOperationException($"No CommandHandler is registered for {typeof(TCommand).Name}");
        }

        await handler.HandleAsync(command, cancellationToken);
        await unitOfWork.SaveChangesAsync();
    }
}

