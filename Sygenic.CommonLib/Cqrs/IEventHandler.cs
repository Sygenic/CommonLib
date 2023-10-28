namespace Sygenic.CommonLib;

public interface IEventHandler<in E> where E : IEvent
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="evnt"></param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task, not ValueTask, so Task.WaitAll can run in dispatcher</returns>
	Task HandleEventAsync(E evnt, CancellationToken cancellationToken);
}