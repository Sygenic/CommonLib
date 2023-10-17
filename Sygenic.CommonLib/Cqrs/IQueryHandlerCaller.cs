namespace Sygenic.CommonLib;

public interface IQueryHandlerCaller<R>
{
	ValueTask<R> CallQueryHandlerAsyc(IQuery<R> query, CancellationToken cancellationToken);
}