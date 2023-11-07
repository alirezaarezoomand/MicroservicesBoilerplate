using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Seedworks.Infrastructure.Persistence.EntityFramework;

public class GeneralDbContext : DbContext
{
    private readonly IDbContextsAssemblyResolver _dbContextsAssemblyResolver;
    private readonly IConfiguration _configuration;

    public GeneralDbContext(DbContextOptions<GeneralDbContext> options,
        IDbContextsAssemblyResolver dbContextsAssemblyResolver,
        IConfiguration configuration)
        : base(options)
    {
        _dbContextsAssemblyResolver = dbContextsAssemblyResolver;
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var assembly in _dbContextsAssemblyResolver.GetAssemblies())
        {
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
        var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        return result;
    }

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}
