namespace Cqrs;

internal sealed record ValueProviderQuery(ValueProvider provider) : IQuery<int>;

internal sealed class ValueProviderQueryHelper : IQueryHandler<ValueProviderQuery, int>
{
	public Task<int> HandleAsync(ValueProviderQuery query, CancellationToken cancellationToken)
		=> Task.FromResult(query.provider.Value);
}