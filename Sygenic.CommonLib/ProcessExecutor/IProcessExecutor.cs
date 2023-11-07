#pragma warning disable CA1068 // CancellationToken parameters must come last

namespace Sygenic.CommonLib;

public interface IProcessExecutor
{
	Task<ProcessOutcome> StartAsync(
		CancellationToken cancellationToken,
		string? workingDir,
		string executable,
		params object[] args);
}

#pragma warning restore CA1068 // CancellationToken parameters must come last