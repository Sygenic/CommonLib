namespace Sygenic.CommonLib;

public interface ICqrsDispatcher
{
	Task<R> RunQueryAsync<R>(IQuery<R> query, CancellationToken cancellationToken);
	Task RunCommandAsync<C>(C command, CancellationToken cancellationToken) where C : ICommand;
	
}