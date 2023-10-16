namespace Sygenic.CommonLib;

/// <summary>
/// Means that logic came to the point when program should no be and it is programmer's fault
/// </summary>
[Serializable]
public sealed class ShouldNotBeHereException : BaseIfException<ShouldNotBeHereException>
{
	public ShouldNotBeHereException()
	{
	}

	public ShouldNotBeHereException(string? message) : base(message)
	{
	}
}