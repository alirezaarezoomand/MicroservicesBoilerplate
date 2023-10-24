namespace Seedworks.Core.Commands;

public interface ICommandBus
{
    Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : ICommand;
}