namespace Sygenic.CommonLib;

internal sealed class CqrsDispatcher : ICqrsDispatcher
{
	private readonly IQueryHandlerProvider queryHandlerProvider;
	private readonly IServiceProvider serviceProvider;

	public CqrsDispatcher(IQueryHandlerProvider queryHandlerProvider, IServiceProvider serviceProvider)
	{
		this.queryHandlerProvider = queryHandlerProvider;
		this.serviceProvider = serviceProvider;
	}

	public async ValueTask<TResponse> ExecuteQueryAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken)
	{
		var handlerType = queryHandlerProvider.GetHandlerForQuery(query);
		using var scope = serviceProvider.CreateScope();
		var handlerCaller = scope.ServiceProvider.GetRequiredService(handlerType) as IQueryHandlerCaller<TResponse>
			?? throw new ShouldNotBeHereException($"Service casted to {nameof(IQueryHandlerCaller<TResponse>)} is null");

		return await handlerCaller.CallQueryHandlerAsyc(query, cancellationToken);
	}

	public async ValueTask ExecuteCommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
		where TCommand : ICommand
	{
		using var scope = serviceProvider.CreateScope();
		var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
		await handler.HandleAsync(command, cancellationToken);
	}
}