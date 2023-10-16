namespace Sygenic.CommonLib;

[Tested]
public interface ISerializer
{
	string ToJson(object obj, bool prettify = false);
	T FromJson<T>(string json);
	void PopulateObject(object obj, string json);
}
