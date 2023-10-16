namespace Sygenic.CommonLib;

[NotTested]
public class DeserializationException : Exception
{
	public DeserializationException()
	{
	}

	public DeserializationException(string? message) : base(message)
	{
	}

	public DeserializationException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}