namespace Cqrs;

internal sealed record ProviderValueQuery(Provider provider) : IQuery<int>;

internal sealed class ProviderValueQueryHandler : IQueryHandler<ProviderValueQuery, int>
{
	public ValueTask<int> HandleAsync(ProviderValueQuery query, CancellationToken cancellationToken)
		=> ValueTask.FromResult(query.provider.Value);
}