namespace XTests;

public class BaseIfException_
{
	[Fact]
	public void _()
	{
		SomeException.ThrowIf(false);
		Assert.Throws<SomeException>(() => SomeException.ThrowIf(true));
	}

	class SomeException : BaseIfException<SomeException>
	{
	}
}
