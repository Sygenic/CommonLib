namespace Sygenic.CommonLib;

[Tested]
internal sealed class ColorConsoleHelper(
	ILogger<ColorConsoleHelper> logger, 
	IOptions<ColorConsoleSettings> options) : IColorConsoleHelper
{
	public void MaybeDisplayAllEnabledLogLevels()
	{
		if (options.Value.DisplayAllEnabledLogLevelsOnStart)
		{
			logger.LogTrace("TRACE log level is on");
			logger.LogDebug("DEBUG log level is on");
			logger.LogInformation("INFO log level is on");
			logger.LogWarning("WARN log level is on");
			logger.LogError("ERROR log level is on");
			logger.LogCritical("CRITICAL log level is on");
		}
	}
}
