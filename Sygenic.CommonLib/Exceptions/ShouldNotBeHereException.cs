namespace Sygenic.CommonLib;

/// <summary>
/// Means that logic came to the point when program should no be and it is programmer's fault
/// </summary>
public sealed class ShouldNotBeHereException(string message) : BaseIfWithMessageException<ShouldNotBeHereException>(message);