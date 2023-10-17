namespace Sygenic.CommonLib;

public interface ICommandDispatcher
{
	ValueTask ExecuteCommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand;
}