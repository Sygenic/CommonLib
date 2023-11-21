namespace Sygenic.CommonLib;

public interface IQueryHandlerCaller<R>
{
	Task<R> CallQueryHandlerAsyc(IQuery<R> query, CancellationToken cancellationToken);
}