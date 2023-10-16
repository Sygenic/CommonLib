namespace Sygenic.CommonLib;

[Tested]
public sealed class ColorConsoleSettings : ConsoleFormatterOptions
{
	/// <summary>
	/// How to format the time of the event. If null/empty - datetime is hidden.
	/// </summary>
	public string DateTimeFormat { get; set; } = "";

	/// <summary>
	/// How long to display the last element of the category. If 0 or less - category is hidden
	/// </summary>
	public int Category { get; set; } = 0;

	public bool DisplayAllEnabledLogLevelsOnStart { get; set; } = true;

	public LogLevelsColors Colors { get; set; } = new();
}