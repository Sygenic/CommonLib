namespace Sygenic.CommonLib;

[Tested]
internal sealed class HelpFile : IHelpFile
{
	#region ctor DI
	private readonly HelpFileSettings settings;
	private readonly ILogger<HelpFile> logger;

	public HelpFile(IOptions<HelpFileSettings> options, ILogger<HelpFile> logger)
	{
		this.settings = options.Value;
		this.logger = logger;
	}

	public void MaybeDisplayHelpFile()
	{
		if (settings.DisplayHelpFile) logger.LogInformation("{help}", File.ReadAllText(settings.HelpFilePath));
	}
	#endregion
}
