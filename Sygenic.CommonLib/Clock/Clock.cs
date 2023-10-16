namespace Sygenic.CommonLib;

[Tested]
internal class Clock : IClock
{
	public DateTime UtcNow => DateTime.UtcNow;
}
