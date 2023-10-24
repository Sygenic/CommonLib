namespace Sygenic.CommonLib;

internal sealed class CqrsDispatcher : ICqrsDispatcher
{
	private readonly IHandlerProvider handlerProvider;
	private readonly IServiceProvider serviceProvider;

	public CqrsDispatcher(IHandlerProvider handlerProvider, IServiceProvider serviceProvider)
	{
		this.handlerProvider = handlerProvider;
		this.serviceProvider = serviceProvider;
	}

	public async ValueTask<R> RunQueryAsync<R>(IQuery<R> query, CancellationToken cancellationToken)
	{
		var handlerType = handlerProvider.GetQueryHandlerType(query);
		using var scope = serviceProvider.CreateScope();
		var handlerCaller = scope.ServiceProvider.GetRequiredService(handlerType) as IQueryHandlerCaller<R>
			?? throw new ShouldNotBeHereException($"Service casted to {nameof(IQueryHandlerCaller<R>)} is null");

		return await handlerCaller.CallQueryHandlerAsyc(query, cancellationToken);
	}

	public async ValueTask RunCommandAsync<C>(C command, CancellationToken cancellationToken) where C : ICommand
	{
		using var scope = serviceProvider.CreateScope();
		var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<C>>();
		await handler.HandleAsync(command, cancellationToken);
	}

	[Obsolete("works for just one handler, needs to be for many handlers")]
	public async Task DispatchEventAsync<E>(E evnt, CancellationToken cancellationToken) where E : IEvent
	{
		using var scope = serviceProvider.CreateScope();
		var handlerTypes = handlerProvider.GetEventHandlerTypes(evnt);
		var handlerTypesCount = handlerTypes.Count();
		var tasks = new List<Task>();
		foreach (var handlerType in handlerTypes)
		{
			var handler = scope.ServiceProvider.GetRequiredService(handlerType) as IEventHandler<E> 
				?? throw new ShouldNotBeHereException("Handler type not found or not IEventHandler<E>");

			var task = handler.HandleEventAsync(evnt, cancellationToken);

			tasks.Add(task);
		}
		await Task.WhenAll(tasks);
	}
}