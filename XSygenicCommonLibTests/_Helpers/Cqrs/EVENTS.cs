namespace Cqrs;

internal sealed record EventA(ValueProvider provider) : IEvent;

internal sealed record EventB(ValueProvider provider) : IEvent;

internal sealed record EventAHandler1 : IEventHandler<EventA>
{
	public Task HandleEventAsync(EventA evnt, CancellationToken cancellationToken)
	{
		evnt.provider.Value += 3;
		return Task.CompletedTask;
	}
}

internal sealed record EventAHandler2 : IEventHandler<EventA>
{
	public Task HandleEventAsync(EventA evnt, CancellationToken cancellationToken)
	{
		evnt.provider.Value += 5;
		return Task.CompletedTask;
	}
}

internal sealed record EventBHandler1 : IEventHandler<EventB>
{
	public Task HandleEventAsync(EventB evnt, CancellationToken cancellationToken) => throw new NotImplementedException();
}

internal sealed record EventBHandler2 : IEventHandler<EventB>
{
	public Task HandleEventAsync(EventB evnt, CancellationToken cancellationToken) => throw new NotImplementedException();
}