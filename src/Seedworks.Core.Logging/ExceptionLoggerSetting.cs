namespace Seedworks.Core.Logging;

public class ExceptionLoggerSetting
{
    public bool IsActive { get; set; }
    public string ApplicationName { get; set; }
    public string ExceptionLogRepositoryConnectionString { get; set; }
}