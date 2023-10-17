namespace Sygenic.CommonLib;

/// <summary>
/// Implement IQuery if:
/// - there is only one handler for a Query
/// - handler is not changing state
/// - result from Query is a TResponse instance
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface IQuery<out TResponse>
{
}