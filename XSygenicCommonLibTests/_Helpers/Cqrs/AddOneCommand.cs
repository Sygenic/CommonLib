namespace Cqrs;

internal sealed record AddOneCommand(Provider provider) : ICommand;