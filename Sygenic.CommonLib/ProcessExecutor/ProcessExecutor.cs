namespace Sygenic.CommonLib;

internal class ProcessExecutor : IProcessExecutor
{
	public async Task<ProcessOutcome> StartAsync(CancellationToken cancellationToken, string? workingDir, string executable, params object[] args)
	{
		var arguments = new string[args.Length];
		for (int index = 0; index < arguments.Length; index++)
		{
			arguments[index] = args[index]?.ToString() ?? "";
		}

		var startInfo = new ProcessStartInfo(executable, string.Join(' ', arguments))
		{
			CreateNoWindow = true,
			UseShellExecute = true,
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			WindowStyle = ProcessWindowStyle.Hidden,
		};

		if (workingDir is not null)
		{
			startInfo.WorkingDirectory = workingDir;
		}

		using var process = Process.Start(startInfo) ?? throw new ProcessExecutorStartException(executable, arguments);
		
		await process.WaitForExitAsync(cancellationToken).ConfigureAwait(false);
		var processOutcome = new ProcessOutcome(Output: process.StandardOutput.ReadToEnd(), Error: process.StandardError.ReadToEnd(), ExitCode: process.ExitCode);
		return processOutcome;
	}
}
