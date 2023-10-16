namespace Sygenic.CommonLib;

/// <summary>
/// Marks any TODO information in more informative way than TODO comment
/// </summary>
[Tested]
[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
public class TODOAttribute : BaseValueAttribute<object[]>
{
	public TODOAttribute(params object[] values) : base(values)
	{
	}
}