namespace Cqrs;

internal sealed record EchoQuery(string Input) : IQuery<string>;