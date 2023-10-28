namespace Sygenic.CommonLib;

[Tested]
public abstract class BaseIfWithMessageException<T> : Exception where T: Exception
{
	/// <summary>
	/// Throws new T exception if condition is met
	/// </summary>
	/// <param name="condition"></param>
	/// <exception cref="T"></exception>
	public static void ThrowIf(bool condition, string message)
	{
		if (condition)
		{
			var exception = Activator.CreateInstance(typeof(T), [message])
				?? new ShouldNotBeHereException($"Unable to create instance of {typeof(T)} using Activator.CreateInstance");

			throw exception as Exception
				?? new ShouldNotBeHereException($"Unable to cast created {typeof(T)} to Exception");
		}
	}

	protected BaseIfWithMessageException(string? message) : base(message)
	{
	}
}