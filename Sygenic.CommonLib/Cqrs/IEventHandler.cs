namespace Sygenic.CommonLib;

public interface IEventHandler<in E> where E : IEvent
{
	Task HandleAsync(E evnt, CancellationToken cancellationToken);
}