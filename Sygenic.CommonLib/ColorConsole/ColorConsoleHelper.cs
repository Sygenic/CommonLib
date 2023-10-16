namespace Sygenic.CommonLib;

[Tested]
internal sealed class ColorConsoleHelper : IColorConsoleHelper
{
	#region ctor DI
	private readonly ILogger<ColorConsoleHelper> logger;
	private readonly ColorConsoleSettings settings;

	public ColorConsoleHelper(ILogger<ColorConsoleHelper> logger, IOptions<ColorConsoleSettings> options)
	{
		this.logger = logger;
		settings = options.Value;
	} 
	#endregion

	public void MaybeDisplayAllEnabledLogLevels()
	{
		if (settings.DisplayAllEnabledLogLevelsOnStart)
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
