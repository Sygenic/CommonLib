namespace Cqrs;

internal sealed class EchoQueryHandler : IQueryHandler<EchoQuery, string>
{
	public ValueTask<string> HandleAsync(EchoQuery query, CancellationToken cancellationToken) 
		=> ValueTask.FromResult($"{query.Input} {query.Input}");
}
