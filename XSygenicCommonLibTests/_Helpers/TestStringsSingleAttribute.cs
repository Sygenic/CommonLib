namespace _Helpers;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class TestStringsSingleAttribute : BaseValueAttribute<string[]>
{
	public TestStringsSingleAttribute(params string[] values) : base(values)
	{
	}
}
