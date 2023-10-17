namespace Cqrs;

internal sealed class AddOneCommandHandler : ICommandHandler<AddOneCommand>
{
	public ValueTask HandleAsync(AddOneCommand command, CancellationToken cancellationToken)
	{
		command.provider.Value++;
		return ValueTask.CompletedTask;
	}
}