namespace Cqrs;

internal sealed class UtcNowQueryHandler : IQueryHandler<UtcNowQuery, DateTime>
{
	public ValueTask<DateTime> HandleAsync(UtcNowQuery query, CancellationToken cancellationToken) 
		=> ValueTask.FromResult(DateTime.MaxValue);
}
