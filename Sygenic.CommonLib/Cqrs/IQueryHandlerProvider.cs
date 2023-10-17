namespace Sygenic.CommonLib;

public interface IQueryHandlerProvider
{
	Type GetHandlerForQuery<TResponse>(IQuery<TResponse> query);
}