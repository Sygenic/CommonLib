namespace Sygenic.CommonLib;

public interface ICqrsDispatcher
{
	ValueTask<TResponse> ExecuteQueryAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken);

	ValueTask ExecuteCommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken) 
		where TCommand : ICommand;
}