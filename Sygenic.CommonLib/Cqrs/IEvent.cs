namespace Sygenic.CommonLib;

/// <summary>
/// Implement IEvent if
/// - there is one or more event handlers
/// - order of handlers' execution does not matter
/// - event handler does not return value
/// </summary>
public interface IEvent
{
}