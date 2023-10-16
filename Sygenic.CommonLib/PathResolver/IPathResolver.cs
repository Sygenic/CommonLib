namespace Sygenic.CommonLib;

[Tested]
public interface IPathResolver
{
	/// <summary>
	/// Get property info using dotted path
	/// Throws in case of failure
	/// </summary>
	/// <param name="root"></param>
	/// <param name="path"></param>
	/// <returns></returns>
	(object, PropertyInfo) GetOwnerAndProperty(object root, string path);

	/// <summary>
	/// Get property info using dotted path
	/// No throwing
	/// </summary>
	/// <param name="target"></param>
	/// <param name="path"></param>
	/// <returns>Null in case of failure</returns>
	(object?, PropertyInfo?) GetOwnerAndPropertySafe(object target, string path);

	/// <summary>
	/// Resolve value of property using dotted path
	/// Throws in case of failure
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="root"></param>
	/// <param name="path"></param>
	/// <returns></returns>
	T GetValue<T>(object root, string path);

	/// <summary>
	/// Resolve value of property using dotted path
	/// Throws in case of failure
	/// </summary>
	/// <param name="target"></param>
	/// <param name="path"></param>
	/// <returns></returns>
	object GetValue(object target, string path);

	/// <summary>
	/// Resolve value of property using dotted path
	/// No throwing
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="target"></param>
	/// <param name="path"></param>
	/// <returns>Null when not found/></returns>
	T? GetValueSafe<T>(object target, string path);

	/// <summary>
	/// Resolve value of property using dotted path
	/// No throwing
	/// </summary>
	/// <param name="targer"></param>
	/// <param name="path"></param>
	/// <returns></returns>
	object? GetValueSafe(object targer, string path);

	void SetValue(object root, string path, object value);
}