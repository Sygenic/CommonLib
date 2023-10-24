using System.Diagnostics;

namespace ImplementationProvider;

public class HasAttribute_GetMethodsHaving
{
	private static readonly string[] expected = ["1", "2", "3"];

	[Fact]
	public void _()
	{
		var implementationProvider = TestHost.Services.Get<IImplementationProvider>();
		var type = typeof(SomeClass);
		var someMethodInfo = type.GetMethod(nameof(SomeClass.SomeMethod)) ?? throw new Exception();
		var someOtherMethodInfo = type.GetMethod(nameof(SomeClass.SomeOtherMethod)) ?? throw new Exception();
		Assert.True(implementationProvider.HasAttribute<DebuggerNonUserCodeAttribute>(someMethodInfo));
		Assert.False(implementationProvider.HasAttribute<DebuggerNonUserCodeAttribute>(someOtherMethodInfo));
		var having = implementationProvider.GetMethodsHaving<DebuggerNonUserCodeAttribute>(type).ToList();
		Assert.Equal(2, having.Count);
		Assert.Contains(someMethodInfo, having);
		Assert.Contains(type.GetMethod(nameof(SomeClass.ThirdMethod)) ?? throw new Exception(), having);
		Assert.Equal(expected, implementationProvider.GetAttributeValue<string[], TestStringsSingleAttribute>(someOtherMethodInfo).OrderBy(x => x).ToArray());
	}
	
	static class SomeClass
	{
		[DebuggerNonUserCode]
		public static void SomeMethod()
		{
		}

		[TestStringsSingle("1", "2", "3")]
		public static void SomeOtherMethod()
		{
		}

		[DebuggerNonUserCode]
		public static void ThirdMethod()
		{
		}

		public static void FourthMethod()
		{
		}
	}
}
