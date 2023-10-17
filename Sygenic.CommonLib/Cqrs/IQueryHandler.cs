namespace Sygenic.CommonLib;

public interface IQueryHandler<in TQuery, TResponse> : IQueryHandlerCaller<TResponse> where TQuery : IQuery<TResponse>
{
	ValueTask<TResponse> HandleAsync(TQuery query, CancellationToken cancellationToken);

	async ValueTask<TResponse> IQueryHandlerCaller<TResponse>.CallQueryHandlerAsyc(IQuery<TResponse> query, CancellationToken cancellationToken) => 
		await HandleAsync((TQuery)query, cancellationToken).ConfigureAwait(false);
}