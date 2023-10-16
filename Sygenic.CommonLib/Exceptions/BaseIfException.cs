namespace Sygenic.CommonLib;

[Tested]
public abstract class BaseIfException<T> : Exception where T: Exception, new()
{
	/// <summary>
	/// Throws new T exception if condition is met
	/// </summary>
	/// <param name="condition"></param>
	/// <exception cref="T"></exception>
	public static void ThrowIf(bool condition)
	{
		if (condition) throw new T();
	}

	protected BaseIfException()
	{
	}

	public BaseIfException(string? message) : base(message)
	{
	}
}