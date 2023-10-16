namespace _Helpers;

public sealed class MultiplyCmd : ICmd<MultiplyContex>
{
    public static string Name { get; } = "multiply";

    public Task<bool> CanExecuteAsync(MultiplyContex context, CancellationToken cancellationToken) => Task.FromResult(true);

    public Task<bool> CanExecuteAsync(CancellationToken cancellationToken) => Task.FromResult(true);

    public Task ExecuteAsync(MultiplyContex context, CancellationToken cancellationToken)
    {
        context.output = 1;
        foreach (var item in context.input) context.output *= item;
        return Task.CompletedTask;
    }

    public Task ExecuteAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}

public sealed class MultiplyContex
{
    public int[] input = Array.Empty<int>();
    public int output;
}