namespace Seedworks.Core.Logging;

public interface IActivityLogger
{
    void StartActivityLog(string activityName, object data = null);

    void EndActivityLog(string activityName, object data = null);
}
