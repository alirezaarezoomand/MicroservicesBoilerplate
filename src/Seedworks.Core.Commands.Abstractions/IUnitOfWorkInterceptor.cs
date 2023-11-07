namespace Seedworks.Core.Commands;

public interface IUnitOfWorkInterceptor
{
    Task BeforSaveChangesAsync(CancellationToken cancellationToken = default);
    Task AfterSaveChangesAsync(CancellationToken cancellationToken = default);
}