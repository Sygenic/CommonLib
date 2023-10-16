using System.Diagnostics;

namespace ImplementationProvider;

public class HasAttribute_GetMethodsHaving
{
	[Fact]
	public void _()
	{
		var implementationProvider = X.Services.Get<IImplementationProvider>();
		var type = typeof(SomeClass);
		var someMethodInfo = type.GetMethod(nameof(SomeClass.SomeMethod)) ?? throw new Exception();
		var someOtherMethodInfo = type.GetMethod(nameof(SomeClass.SomeOtherMethod)) ?? throw new Exception();
		Assert.True(implementationProvider.HasAttribute<DebuggerNonUserCodeAttribute>(someMethodInfo));
		Assert.False(implementationProvider.HasAttribute<DebuggerNonUserCodeAttribute>(someOtherMethodInfo));
		var having = implementationProvider.GetMethodsHaving<DebuggerNonUserCodeAttribute>(type).ToList();
		Assert.Equal(2, having.Count);
		Assert.Contains(someMethodInfo, having);
		Assert.Contains(type.GetMethod(nameof(SomeClass.ThirdMethod)) ?? throw new Exception(), having);
		Assert.Equal(new string[] { "1", "2", "3" }, implementationProvider.GetAttributeValue<string[], TestStringsSingleAttribute>(someOtherMethodInfo).OrderBy(x => x).ToArray());
	}
	
	class SomeClass
	{
		[DebuggerNonUserCode]
		public void SomeMethod()
		{
		}

		[TestStringsSingle("1", "2", "3")]
		public void SomeOtherMethod()
		{
		}

		[DebuggerNonUserCode]
		public void ThirdMethod()
		{
		}

		public void FourthMethod()
		{
		}
	}
}
