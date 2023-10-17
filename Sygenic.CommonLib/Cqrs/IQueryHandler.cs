namespace Sygenic.CommonLib;

public interface IQueryHandler<in Q, R> : IQueryHandlerCaller<R> where Q : IQuery<R>
{
	ValueTask<R> HandleAsync(Q query, CancellationToken cancellationToken);

	async ValueTask<R> IQueryHandlerCaller<R>.CallQueryHandlerAsyc(
		IQuery<R> query, CancellationToken cancellationToken) => await HandleAsync((Q)query, cancellationToken);
}