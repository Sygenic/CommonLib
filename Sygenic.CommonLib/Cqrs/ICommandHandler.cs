namespace Sygenic.CommonLib;

public interface ICommandHandler<in C> where C : ICommand
{
	Task HandleAsync(C command, CancellationToken cancellationToken);
}