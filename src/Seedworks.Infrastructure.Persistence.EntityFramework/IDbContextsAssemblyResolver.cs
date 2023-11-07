using System.Reflection;

namespace Seedworks.Infrastructure.Persistence.EntityFramework;

public interface IDbContextsAssemblyResolver
{
    List<Assembly> GetAssemblies();
}
