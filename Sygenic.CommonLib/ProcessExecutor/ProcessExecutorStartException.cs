namespace Sygenic.CommonLib;

public class ProcessExecutorStartException : Exception
{
	private string executable;
	private string[] arguments;

	public ProcessExecutorStartException(string executable, string[] arguments)
	{
		this.executable = executable;
		this.arguments = arguments;
	}
}