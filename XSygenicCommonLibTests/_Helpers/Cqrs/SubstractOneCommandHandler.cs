namespace Cqrs;

internal sealed record SubstractOneCommand(Provider provider) : ICommand;

internal sealed class SubstractOneCommandHandler : ICommandHandler<SubstractOneCommand>
{
	public ValueTask HandleAsync(SubstractOneCommand command, CancellationToken cancellationToken)
	{
		command.provider.Value--;
		return ValueTask.CompletedTask;
	}
}