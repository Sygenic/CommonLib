namespace Sygenic.CommonLib;

[Tested]
public sealed class ColorConsole : ConsoleFormatter
{
	#region ctor
	private readonly ColorConsoleSettings cyberConsoleSettings;
	private readonly Dictionary<LogLevel, Color> ColorPairs;
	private readonly string EmptyNCharsLongString;

	public ColorConsole(IOptions<ColorConsoleSettings> options) : base(nameof(ColorConsole))
	{
		cyberConsoleSettings = options.Value;
		ColorPairs = new Dictionary<LogLevel, Color>
		{
			{ LogLevel.None, ColorTranslator.FromHtml(cyberConsoleSettings.Colors.None) },
			{ LogLevel.Trace, ColorTranslator.FromHtml(cyberConsoleSettings.Colors.Trace) },
			{ LogLevel.Debug,ColorTranslator.FromHtml(cyberConsoleSettings.Colors.Debug) },
			{ LogLevel.Information, ColorTranslator.FromHtml(cyberConsoleSettings.Colors.Information) },
			{ LogLevel.Warning, ColorTranslator.FromHtml(cyberConsoleSettings.Colors.Warning) },
			{ LogLevel.Error, ColorTranslator.FromHtml(cyberConsoleSettings.Colors.Error) },
			{ LogLevel.Critical, ColorTranslator.FromHtml(cyberConsoleSettings.Colors.Critical) }
		};
		EmptyNCharsLongString = new string(' ', cyberConsoleSettings.Category);
	}
	#endregion

	public override void Write<TState>(in LogEntry<TState> logEntry, IExternalScopeProvider? scopeProvider, TextWriter textWriter)
	{
		var msg = logEntry.Formatter?.Invoke(logEntry.State, logEntry.Exception);

		if (msg is not null)
		{
			msg = MaybePrependCategory(logEntry.Category, msg);
			msg = MaybePrependDateTime(msg);
			msg = MaybeColorize(logEntry.LogLevel, msg);
			textWriter.WriteLine(msg);
		}
	}

	private string MaybeColorize(LogLevel logLevel, string msg) => cyberConsoleSettings.Colors.Enabled ? msg.Pastel(ColorPairs[logLevel]) : msg;

	private string MaybePrependCategory(string category, string msg)
	{
		if (cyberConsoleSettings.Category <= 0)
		{
			return msg;
		}

		var dot = category.LastIndexOf('.') + 1;
		var concatenated = string.Concat(category[dot..], EmptyNCharsLongString);

		return $"{concatenated[..cyberConsoleSettings.Category]} {msg}";
	}

	private string MaybePrependDateTime(string msg)
	{
		if (string.IsNullOrWhiteSpace(cyberConsoleSettings.DateTimeFormat))
		{
			return msg;
		}

		var now = DateTime.Now.ToString(cyberConsoleSettings.DateTimeFormat);
		return $"{now} {msg}";
	}
}