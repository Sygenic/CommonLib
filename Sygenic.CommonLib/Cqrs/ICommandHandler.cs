namespace Sygenic.CommonLib;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
	ValueTask HandleAsync(TCommand command, CancellationToken cancellationToken);
}