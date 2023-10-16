namespace Sygenic.CommonLib;

[Tested]
public interface IPersistence
{
	Task<T> LoadAsync<T>(string id) where T : IHasId;
	Task SaveAsync(params IHasId[] data);
	Task DeleteAsync(params string[] id);
	Task DeleteAsync(params IHasId[] data) => DeleteAsync(data.Select(x => x.Id).ToArray());
	Task<bool> ExistsAsync(string id);
	Task<bool> ExistsAsync(IHasId data) => ExistsAsync(data.Id);
	IQueryable<T> Query<T>() where T: IHasId;
}
