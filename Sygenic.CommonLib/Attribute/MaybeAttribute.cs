namespace Sygenic.CommonLib;

/// <summary>
/// Anything worth to remember regarding marked member, like 
/// Maybe("this should be refactored into xyz") or Maybe(0, 1, 2, "will work better)
/// </summary>
[Tested]
[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
public class MaybeAttribute : BaseValueAttribute<object[]>
{
	public MaybeAttribute(params object[] values) : base(values)
	{
	}
}