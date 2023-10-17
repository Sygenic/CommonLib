namespace Cqrs;

internal sealed record UtcNowQuery : IQuery<DateTime>;