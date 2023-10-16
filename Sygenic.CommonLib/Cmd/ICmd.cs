namespace Sygenic.CommonLib;

/// <summary>
/// Simple command without any context
/// </summary>
[NotTested]
public interface ICmd
{
	static string Name { get; } = "";

	Task<bool> CanExecuteAsync(CancellationToken cancellationToken);

	Task ExecuteAsync(CancellationToken cancellationToken);
}

/// <summary>
/// Command which runs with some context
/// </summary>
/// <typeparam name="CONTEXT"></typeparam>
[NotTested]
public interface ICmd<CONTEXT> : ICmd where CONTEXT: notnull
{
	Task<bool> CanExecuteAsync(CONTEXT context, CancellationToken cancellationToken);

	Task ExecuteAsync(CONTEXT context, CancellationToken cancellationToken);
}