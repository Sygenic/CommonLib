namespace Sygenic.CommonLib;

[Tested]
public sealed class MemoryPersistence : IPersistence
{
	private readonly ConcurrentDictionary<string, IHasId> storage = new();

	public Task DeleteAsync(params string[] id)
	{
		foreach (var item in id)
		{
			storage.Remove(item, out var _);
		}
		return Task.CompletedTask;
	}

	public Task<bool> ExistsAsync(string id) => Task.FromResult(storage.ContainsKey(id));

	public Task<T> LoadAsync<T>(string id) where T : IHasId => Task.FromResult((T)storage[id]);

	public Task SaveAsync(params IHasId[] data)
	{
		foreach (var item in data)
		{
			storage[item.Id] = item;
		}
		return Task.CompletedTask;
	}

	public IQueryable<T> Query<T>() where T : IHasId => storage.Values.OfType<T>().AsQueryable();
}