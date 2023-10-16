namespace Sygenic.CommonLib;

[Tested]
public sealed class LogLevelsColors
{
	public bool Enabled { get; set; } = true;

	public string None { get; set; } = "Black";
	public string Trace { get; set; } = "Gray";
	public string Debug { get; set; } = "White";
	public string Information { get; set; } = "Lime";
	public string Warning { get; set; } = "Orange";
	public string Error { get; set; } = "Red";
	public string Critical { get; set; } = "Magenta";
}