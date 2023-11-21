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

	public async Task DispatchEventAsync<E>(E evnt, CancellationToken cancellationToken) where E : IEvent
	{
		using var scope = serviceProvider.CreateScope();
		var handlerTypes = handlerProvider.GetEventHandlerTypes(evnt);
		var tasks = new List<Task>();
		foreach (var handlerType in handlerTypes)
		{
			var handler = scope.ServiceProvider.GetRequiredService(handlerType) as IEventHandler<E> 
				?? throw new ShouldNotBeHereException($"Handler type not found or not {nameof(IEventHandler<E>)}");

			tasks.Add(handler.HandleAsync(evnt, cancellationToken));
		}
		await Task.WhenAll(tasks);
	}
}