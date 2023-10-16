namespace Sygenic.CommonLib;

[Tested]
public static class ColorConsoleLoggerExtensions
{
	public static ILoggingBuilder AddCyberConsole(this ILoggingBuilder builder) =>
			builder
					.AddConsole(options => options.FormatterName = nameof(ColorConsole))
					.AddConsoleFormatter<ColorConsole, ColorConsoleSettings>();

	public static ILoggingBuilder AddCyberConsole(this ILoggingBuilder builder, Action<ColorConsoleSettings> configure) =>
			builder
					.AddConsole(options => options.FormatterName = nameof(ColorConsole))
					.AddConsoleFormatter<ColorConsole, ColorConsoleSettings>(configure);
}