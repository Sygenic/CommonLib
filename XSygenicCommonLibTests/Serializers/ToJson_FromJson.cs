namespace Serializers;

public class ToJson_FromJson
{
	[Fact]
	public void _()
	{
		var serializer = X.Services.Get<ISerializer>();
		var expected = new SomeRecord(Guid.NewGuid().ToString(), Random.Shared.Next());
		Assert.Equal(expected, serializer.FromJson<SomeRecord>(serializer.ToJson(expected)));
	}

	private record SomeRecord(string str, int n);
}