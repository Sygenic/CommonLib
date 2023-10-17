namespace Sygenic.CommonLib;

public interface ICommandHandler<in C> where C : ICommand
{
	ValueTask HandleAsync(C command, CancellationToken cancellationToken);
}