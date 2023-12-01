namespace Sygenic.CommonLib;

internal interface IHandlerProvider
{
	Type GetQueryHandlerType<R>(IQuery<R> query);
}