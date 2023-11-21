namespace Sygenic.CommonLib;

/// <summary>
/// Implement ICommand if
/// - there is only one handler for a Command
/// - there is no return value (current implementation)
/// - handler is changing state
/// </summary>
public interface ICommand
{
}