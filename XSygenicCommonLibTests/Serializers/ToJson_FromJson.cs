namespace Serializers;

public class ToJson_FromJson
{
	[Fact]
	public void _()
	{
		var serializer = TestHost.Services.Get<ISerializer>();
		var expected = new SomeRecord(Guid.NewGuid().ToString(), Random.Shared.Next());
		Assert.Equal(expected, serializer.Deserialize<SomeRecord>(serializer.Serialize(expected)));
	}

	private record SomeRecord(string str, int n);
}