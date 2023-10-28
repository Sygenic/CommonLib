namespace Sygenic.CommonLib;

[Tested]
internal sealed class Clock : IClock
{
	public DateTime UtcNow => DateTime.UtcNow;
}
