namespace Sygenic.CommonLib;

[Tested]
internal sealed class HelpFile(IOptions<HelpFileSettings> options, ILogger<HelpFile> logger) : IHelpFile
{
	private readonly HelpFileSettings settings = options.Value;

	public void MaybeDisplayHelpFile()
	{
		if (settings.DisplayHelpFile)
		{
			logger.LogInformation("{help}", File.ReadAllText(settings.HelpFilePath));
		}
	}
}
