namespace Serializer_;

public class DeserializationException_
{
	[Fact]
	public void _()
	{
		var serializer = TestHost.Services.Get<ISerializer>();
		Assert.Throws<DeserializationException>(() => serializer.Deserialize<object>(""));
	}
}