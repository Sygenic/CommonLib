namespace Cqrs;

internal sealed record ValueProviderQuery(ValueProvider provider) : IQuery<int>;

internal sealed class ValueProviderQueryHelper : IQueryHandler<ValueProviderQuery, int>
{
	public ValueTask<int> HandleAsync(ValueProviderQuery query, CancellationToken cancellationToken)
		=> ValueTask.FromResult(query.provider.Value);
}