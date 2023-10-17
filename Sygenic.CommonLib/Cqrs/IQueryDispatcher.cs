namespace Sygenic.CommonLib;

public interface IQueryDispatcher
{
	ValueTask<TResponse> ExecuteQueryAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken);
}
