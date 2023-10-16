namespace Sygenic.CommonLib;

/// <summary>
/// When looking for command registered under the name and no command is found
/// </summary>
[NotTested]
public sealed class CmdNotRegisteredException : Exception
{
	public CmdNotRegisteredException(string? commandName) : base(commandName)
	{
	}
}