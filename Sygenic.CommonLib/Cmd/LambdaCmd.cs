namespace Sygenic.CommonLib;

/// <summary>
/// Simple command without context defined by CanExecuteLambda lambda and ExecuteLambda lambda
/// </summary>
[NotTested]
public sealed class LambdaCmd : ICmd
{
	public static string Name { get; } = nameof(LambdaCmd);

	public required string LambdaName { get; init; }

	public required Func<bool> CanExecuteLambda { get; init; }

	public required Action ExecuteLambda { get; init; }

	[Maybe("...pass cancellation token to the lambda")]
	public Task<bool> CanExecuteAsync(CancellationToken cancellationToken) => Task.FromResult(CanExecuteLambda());

	[Maybe("...pass cancellation token to the lambda")]
	public Task ExecuteAsync(CancellationToken cancellationToken)
	{
		ExecuteLambda();
		return Task.CompletedTask;
	}
}
