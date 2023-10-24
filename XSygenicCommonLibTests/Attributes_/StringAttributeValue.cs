namespace Attributes;

[TestStringsSingle("test string")]
public class StringAttributeValue
{
	private static readonly string[] expected = ["test string"];

	[Fact]
	public void _()
	{
		var implementationProvider = TestHost.Services.Get<IImplementationProvider>();
		var testAttributeValues = implementationProvider.GetAttributeValue<string[], TestStringsSingleAttribute>(typeof(StringAttributeValue));
		Assert.Single(testAttributeValues);
		Assert.Equal(expected , testAttributeValues);
		Assert.Throws<NoAttributeFoundException<TestStringsSingleAttribute>>(
			() => implementationProvider.GetAttributeValue<string[], TestStringsSingleAttribute>(typeof(ISomeInterfaceA)));
	}
}
