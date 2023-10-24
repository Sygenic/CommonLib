namespace Sygenic.CommonLib;

public interface ICqrsDispatcher
{
	ValueTask<R> RunQueryAsync<R>(IQuery<R> query, CancellationToken cancellationToken);
	ValueTask RunCommandAsync<C>(C command, CancellationToken cancellationToken) where C : ICommand;
	Task DispatchEventAsync<E>(E evnt, CancellationToken cancellationToken) where E : IEvent;
}