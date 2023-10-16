namespace Sygenic.CommonLib;

/// <summary>
/// Do not use System.DateTime.(Utc)Now, it is not testable
/// Use IClock, for tests provide own fixed implementation
/// </summary>
[Tested]
public interface IClock
{
	DateTime UtcNow { get; }
}