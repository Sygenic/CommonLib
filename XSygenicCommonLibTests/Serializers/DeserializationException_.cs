namespace Serializer_;

public class DeserializationException_
{
	[Fact]
	public void _()
	{
		var serializer = X.Services.Get<ISerializer>();
		Assert.Throws<DeserializationException>(() => serializer.FromJson<object>(""));
	}
}