namespace Sygenic.CommonLib;

/// <summary>
/// Implement ICommand if
/// - there is only one handler for a Command
/// - there is no return /we are going to change that maybe/
/// - handler is changing state
/// </summary>
public interface ICommand
{
}