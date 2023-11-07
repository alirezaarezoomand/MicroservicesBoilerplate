using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Seedworks.Infrastructure.Persistence.EntityFramework.EntityTypeConfigurations;

public abstract class EntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class
{

    internal string Schema { get; }

    public EntityTypeConfiguration(string schema)
    {
        Schema = schema;
    }

    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.ToTable(typeof(TEntity).Name, Schema);

    }
}
