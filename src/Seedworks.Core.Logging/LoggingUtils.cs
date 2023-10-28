using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Seedworks.Core.Logging;

public static class LoggingUtils
{
    public static string GetUserIdentity()
    {
        if (ClaimsPrincipal.Current == null)
        {
            return "";
        }

        var userIdentity = ClaimsPrincipal.Current.Identities.FirstOrDefault(n => n.Claims.Any(m => m.Type == "UserIdentity"));

        if (userIdentity != null)
        {
            var claim = userIdentity.Claims.FirstOrDefault(m => m.Type == "UserIdentity");

            if (claim != null)
            {
                return claim.Value;
            }
        }

        return "";
    }

    public static string GetClientIp()
    {
        if (ClaimsPrincipal.Current == null)
        {
            return "";
        }

        var ip = ClaimsPrincipal.Current.Identities.FirstOrDefault(n => n.Claims.Any(m => m.Type == "IP"));

        if (ip != null)
        {
            var claim = ip.Claims.FirstOrDefault(m => m.Type == "IP");

            if (claim != null)
            {
                return claim.Value;
            }
        }

        return "";
    }

    public static string GetApplicationName(IConfiguration configuration)
    {
        var section = configuration.GetSection("Logger:ApplicationName");

        if(section is not null) 
        {
            return section.Value;
        }

        return "";
    }
}
