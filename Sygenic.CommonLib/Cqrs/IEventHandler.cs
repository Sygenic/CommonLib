namespace Sygenic.CommonLib;

public interface IEventHandler<in E> where E : IEvent
{
	Task HandleEventAsync(E evnt, CancellationToken cancellationToken);
}