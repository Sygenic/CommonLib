namespace Sygenic.CommonLib;

internal sealed class CqrsDispatcher(IHandlerProvider handlerProvider, IServiceProvider serviceProvider) : ICqrsDispatcher
{
	public async Task<R> RunQueryAsync<R>(IQuery<R> query, CancellationToken cancellationToken)
	{
		var handlerType = handlerProvider.GetQueryHandlerType(query);
		using var scope = serviceProvider.CreateScope();
		var handlerCaller = scope.ServiceProvider.GetRequiredService(handlerType) as IQueryHandlerCaller<R>
			?? throw new ShouldNotBeHereException($"Service casted to {nameof(IQueryHandlerCaller<R>)} is null");

		return await handlerCaller.CallQueryHandlerAsyc(query, cancellationToken);
	}

	public async Task RunCommandAsync<C>(C command, CancellationToken cancellationToken) where C : ICommand
	{
		using var scope = serviceProvider.CreateScope();
		var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<C>>();
		await handler.HandleAsync(command, cancellationToken);
	}
}