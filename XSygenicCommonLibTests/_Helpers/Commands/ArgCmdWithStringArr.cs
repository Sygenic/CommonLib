namespace _Helpers;

public sealed class ArgCmdWithStringArr : ICmd<string[]>
{
    public static string Name { get; } = "ArgCmdWithStringArr";

    public Task<bool> CanExecuteAsync(string[] context, CancellationToken cancellationToken) => CanExecuteAsync(cancellationToken);

    public Task<bool> CanExecuteAsync(CancellationToken cancellationToken) => Task.FromResult(true);

    public Task ExecuteAsync(string[] context, CancellationToken cancellationToken) => Task.CompletedTask;
    
    public Task ExecuteAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}