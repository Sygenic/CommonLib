namespace _Helpers;

internal class ASimpleCmd : ICmd
{
    public static string Name { get; } = "1";
    public Task<bool> CanExecuteAsync(CancellationToken cancellationToken) => Task.FromResult(true);
    public Task ExecuteAsync(CancellationToken cancellationToken) => Task.FromResult(true);
}