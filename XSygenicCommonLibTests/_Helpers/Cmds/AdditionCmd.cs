namespace _Helpers;

public sealed class AdditionCmd : ICmd<AdditionContext>
{
    public static string Name { get; } = "addition";

    public Task<bool> CanExecuteAsync(AdditionContext context, CancellationToken cancellationToken) => CanExecuteAsync(cancellationToken);

    public Task<bool> CanExecuteAsync(CancellationToken cancellationToken) => Task.FromResult(true);

    public Task ExecuteAsync(AdditionContext context, CancellationToken cancellationToken)
    {
        context.output = context.input.Sum();
        return Task.CompletedTask;
    }

    public Task ExecuteAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}

public sealed class AdditionContext
{
    public int[] input = Array.Empty<int>();
    public int output;
}