namespace Seedworks.Core.Logging;

public interface IExceptionLogger
{
    void Log(Exception exception);
}
