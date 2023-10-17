namespace Sygenic.CommonLib;

public interface ICqrsDispatcher
{
	ValueTask<R> ExecuteQueryAsync<R>(IQuery<R> query, CancellationToken cancellationToken);

	ValueTask ExecuteCommandAsync<C>(C command, CancellationToken cancellationToken) where C : ICommand;
}