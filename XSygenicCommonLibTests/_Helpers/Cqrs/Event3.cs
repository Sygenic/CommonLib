namespace Cqrs;

internal sealed record Event3(Provider provider) : IEvent;

internal sealed class Event3aHandler : IEventHandler<Event3>
{

}