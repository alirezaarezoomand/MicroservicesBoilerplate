namespace Seedworks.Core.Logging;

public class ActivityLoggerSetting
{
    public bool IsActive { get; set; }
    public bool SaveInputInLog { get; set; }
    public bool SaveOutputInLog { get; set; }
    public string ApplicationName { get; set; }
    public string ActivityLogRepositoryConnectionString { get; set; }
}