namespace Attributes;

[TestStringsSingle("test string")]
public class StringAttributeValue
{
	[Fact]
	public void _()
	{
		var implementationProvider = X.Services.Get<IImplementationProvider>();
		var testAttributeValues = implementationProvider.GetAttributeValue<string[], TestStringsSingleAttribute>(typeof(StringAttributeValue));
		Assert.Single(testAttributeValues);
		Assert.Equal(new string[] { "test string" } , testAttributeValues);
		Assert.Throws<NoAttributeFoundException<TestStringsSingleAttribute>>(
			() => implementationProvider.GetAttributeValue<string[], TestStringsSingleAttribute>(typeof(ISomeInterfaceA)));
	}
}
