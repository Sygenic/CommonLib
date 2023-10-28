namespace Sygenic.CommonLib;

[Tested]
public sealed class ColorConsole(IOptions<ColorConsoleSettings> options) : ConsoleFormatter(nameof(ColorConsole))
{
	private readonly FrozenDictionary<LogLevel, Color> ColorPairs = new Dictionary<LogLevel, Color>
	{
			{ LogLevel.None, ColorTranslator.FromHtml(options.Value.Colors.None) },
			{ LogLevel.Trace, ColorTranslator.FromHtml(options.Value.Colors.Trace) },
			{ LogLevel.Debug,ColorTranslator.FromHtml(options.Value.Colors.Debug) },
			{ LogLevel.Information, ColorTranslator.FromHtml(options.Value.Colors.Information) },
			{ LogLevel.Warning, ColorTranslator.FromHtml(options.Value.Colors.Warning) },
			{ LogLevel.Error, ColorTranslator.FromHtml(options.Value.Colors.Error) },
			{ LogLevel.Critical, ColorTranslator.FromHtml(options.Value.Colors.Critical) }
		}.ToFrozenDictionary();

	private readonly string EmptyNCharsLongString = new(' ', options.Value.Category);

	private readonly ColorConsoleSettings settings = options.Value;

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

	private string MaybeColorize(LogLevel logLevel, string msg) =>
		settings.Colors.Enabled ? msg.Pastel(ColorPairs[logLevel]) : msg;

	private string MaybePrependCategory(string category, string msg)
	{
		if (settings.Category <= 0)
		{
			return msg;
		}

		var dot = category.LastIndexOf('.') + 1;
		var concatenated = string.Concat(category[dot..], EmptyNCharsLongString);

		return $"{concatenated[..settings.Category]} {msg}";
	}

	private string MaybePrependDateTime(string msg)
	{
		if (string.IsNullOrWhiteSpace(settings.DateTimeFormat))
		{
			return msg;
		}

		var now = DateTime.Now.ToString(settings.DateTimeFormat);
		return $"{now} {msg}";
	}
}