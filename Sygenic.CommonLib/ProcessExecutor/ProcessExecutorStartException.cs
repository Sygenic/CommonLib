namespace Sygenic.CommonLib;

public class ProcessExecutorStartException(string executable, string[] arguments) : Exception
{
	public readonly string Executable = executable;
	public readonly string[] Arguments = arguments;
}