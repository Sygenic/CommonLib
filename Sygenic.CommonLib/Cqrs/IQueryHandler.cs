namespace Sygenic.CommonLib;

public interface IQueryHandler<in Q, R> : IQueryHandlerCaller<R> where Q : IQuery<R>
{
	Task<R> HandleAsync(Q query, CancellationToken cancellationToken);

	async Task<R> IQueryHandlerCaller<R>.CallQueryHandlerAsyc(
		IQuery<R> query, CancellationToken cancellationToken) => await HandleAsync((Q)query, cancellationToken);
}