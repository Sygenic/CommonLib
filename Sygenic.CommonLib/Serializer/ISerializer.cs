namespace Sygenic.CommonLib;

public interface ISerializer
{
	string Serialize(object obj, bool prettify = false);
	T Deserialize<T>(string json);
	void PopulateObject(object obj, string serialized);
}
