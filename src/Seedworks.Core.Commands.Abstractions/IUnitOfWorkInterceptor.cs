namespace Seedworks.Core.Commands;

public interface IUnitOfWorkInterceptor
{
    Task AfterBeginTransactionAsync(CancellationToken cancellationToken = default);

    Task BeforSaveChangesAsync(CancellationToken cancellationToken = default);

    Task AfterSaveChangesAsync(CancellationToken cancellationToken = default);

    Task AfterCommitTransactionAsync(CancellationToken cancellationToken = default);

    Task AfterRollbackTransactionAsync(CancellationToken cancellationToken = default);
}