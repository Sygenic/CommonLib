namespace Cqrs;

internal sealed record ProviderValueQuery(Provider provider) : IQuery<int>;