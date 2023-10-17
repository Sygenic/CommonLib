namespace Cqrs;

internal sealed record SubstractOneCommand(Provider provider) : ICommand;