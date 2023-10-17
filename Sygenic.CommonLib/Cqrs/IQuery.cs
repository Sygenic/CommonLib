namespace Sygenic.CommonLib;

/// <summary>
/// Implement IQuery if:
/// - there is only one handler for a Query
/// - handler is not changing state
/// - result from Query is a T instance
/// </summary>
/// <typeparam name="R">Result of query</typeparam>
public interface IQuery<out R>
{
}