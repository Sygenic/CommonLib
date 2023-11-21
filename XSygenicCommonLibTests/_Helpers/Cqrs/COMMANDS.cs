namespace Cqrs;

internal sealed record AddOneCommand(ValueProvider provider) : ICommand;

internal sealed class AddOneCommandHandler : ICommandHandler<AddOneCommand>
{
	public Task HandleAsync(AddOneCommand command, CancellationToken cancellationToken)
	{
		command.provider.Value++;
		return Task.CompletedTask;
	}
}

internal sealed record SubstractOneCommand(ValueProvider provider) : ICommand;

internal sealed class SubstractOneCommandHandler : ICommandHandler<SubstractOneCommand>
{
	public Task HandleAsync(SubstractOneCommand command, CancellationToken cancellationToken)
	{
		command.provider.Value--;
		return Task.CompletedTask;
	}
}