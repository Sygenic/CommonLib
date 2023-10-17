namespace Sygenic.CommonLib;

internal sealed class QueryDispatcher : IQueryDispatcher
{
	private readonly IQueryHandlerProvider queryHandlerProvider;
	private readonly IServiceProvider serviceProvider;

	public QueryDispatcher(IQueryHandlerProvider queryHandlerProvider, IServiceProvider serviceProvider)
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
}