namespace Sygenic.CommonLib;

internal sealed class CommandDispatcher : ICommandDispatcher
{
	private readonly IServiceProvider serviceProvider;

	public CommandDispatcher(IServiceProvider serviceProvider) => this.serviceProvider = serviceProvider;

	public async ValueTask ExecuteCommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
		where TCommand : ICommand
	{
		using var scope = serviceProvider.CreateScope();
		var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
		await handler.HandleAsync(command, cancellationToken);
	}
}