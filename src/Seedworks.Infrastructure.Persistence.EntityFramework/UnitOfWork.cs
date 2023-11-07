using Microsoft.EntityFrameworkCore;
using Seedworks.Core.Commands;
using Seedworks.Core.Domain;
using System.Data;

namespace Seedworks.Infrastructure.Persistence.EntityFramework;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext Context;
    private readonly IDomainEventPublisher _domainEventPublisher;
    private readonly IEnumerable<IUnitOfWorkInterceptor> _unitOfWorkInterceptors;

    public UnitOfWork(DbContext context,
        IEnumerable<IUnitOfWorkInterceptor> unitOfWorkInterceptors,
        IDomainEventPublisher domainEventPublisher)
    {
        Context = context;
        _unitOfWorkInterceptors = unitOfWorkInterceptors;
        _domainEventPublisher = domainEventPublisher;
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (Context.Database.CurrentTransaction == null)
        {
            await Context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        }
    }

    public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await BeforSaveChangesAsync(cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        await AfterSaveChangesAsync(cancellationToken);

        await _domainEventPublisher.PublishEventsAsync();
    }

    public virtual async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (Context.Database.CurrentTransaction == null)
        {
            throw new InvalidOperationException("there is no external transaction");
        }

        await Context.Database.CurrentTransaction.CommitAsync(cancellationToken);
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (Context.Database.CurrentTransaction != null)
        {
            await Context.Database.CurrentTransaction.RollbackAsync(cancellationToken);
        }
    }

    #region interceptor
    private Task BeforSaveChangesAsync(CancellationToken cancellationToken)
    {
        return Task.WhenAll(_unitOfWorkInterceptors.Select(c => c.BeforSaveChangesAsync(cancellationToken)));
    }

    private Task AfterSaveChangesAsync(CancellationToken cancellationToken)
    {
        return Task.WhenAll(_unitOfWorkInterceptors.Select(c => c.AfterSaveChangesAsync(cancellationToken)));
    }
    #endregion

}
