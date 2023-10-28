namespace Exceptions;

public class BasIfWithMessageExceptionTest
{
	[Fact]
	public void _()
	{
		SomeMsgException.ThrowIf(false, "msg");
		try
		{
			SomeMsgException.ThrowIf(true, "msg");
		}
		catch (SomeMsgException actual) 
		{
			var expected = new SomeMsgException("msg");
			Assert.Equal(expected.Message, actual.Message);
		}
	}

	sealed class SomeMsgException(string msg) : BaseIfWithMessageException<SomeMsgException>(msg);
}
