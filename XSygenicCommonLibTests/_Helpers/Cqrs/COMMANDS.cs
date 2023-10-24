namespace Cqrs;

internal sealed record AddOneCommand(ValueProvider provider) : ICommand;

internal sealed class AddOneCommandHandler : ICommandHandler<AddOneCommand>
{
	public ValueTask HandleAsync(AddOneCommand command, CancellationToken cancellationToken)
	{
		command.provider.Value++;
		return ValueTask.CompletedTask;
	}
}

internal sealed record SubstractOneCommand(ValueProvider provider) : ICommand;

internal sealed class SubstractOneCommandHandler : ICommandHandler<SubstractOneCommand>
{
	public ValueTask HandleAsync(SubstractOneCommand command, CancellationToken cancellationToken)
	{
		command.provider.Value--;
		return ValueTask.CompletedTask;
	}
}