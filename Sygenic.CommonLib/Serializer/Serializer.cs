namespace Sygenic.CommonLib;

[Tested]
public class Serializer : ISerializer
{
	public string ToJson(object obj, bool prettify = false) => 
		prettify 
		? Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented) 
		: Newtonsoft.Json.JsonConvert.SerializeObject(obj);

	public T FromJson<T>(string json) => 
		Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json) ?? throw new DeserializationException(json);

	public void PopulateObject(object obj, string json) => Newtonsoft.Json.JsonConvert.PopulateObject(json, obj);
}
