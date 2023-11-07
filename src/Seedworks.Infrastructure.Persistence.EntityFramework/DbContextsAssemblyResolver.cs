using System.Reflection;

namespace Seedworks.Infrastructure.Persistence.EntityFramework;

public class DbContextsAssemblyResolver : IDbContextsAssemblyResolver
{
    private readonly List<Assembly> _assemblies = new List<Assembly>();
    public DbContextsAssemblyResolver(List<Type> dbContextTypes)
    {
        foreach (var context in dbContextTypes)
        {
            _assemblies.Add(context.Assembly);
        }
    }

    public List<Assembly> GetAssemblies()
    {
        return _assemblies;
    }
}
