namespace Cqrs;

internal sealed class ProviderValueQueryHandler : IQueryHandler<ProviderValueQuery, int>
{
	public ValueTask<int> HandleAsync(ProviderValueQuery query, CancellationToken cancellationToken)
		=> ValueTask.FromResult(query.provider.Value);
}
