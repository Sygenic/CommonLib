namespace Sygenic.CommonLib;

[Tested]
[Obsolete("Will be removed in 2024")]
public interface IAttributeMapper
{
	/// <summary>
	/// Call action for every ATTRIBUTE found on SOURCE class where SOURCE is setup from factory into implementation
	/// </summary>
	/// <typeparam name="ATTRIBUTE"></typeparam>
	/// <typeparam name="VALUE"></typeparam>
	/// <param name="action"></param>
	/// <returns></returns>
	IAttributeMapper Map<ATTRIBUTE, VALUE>(Action<VALUE> action) where ATTRIBUTE : BaseValueAttribute<VALUE>;

	/// <summary>
	/// Call action for every ATTRIBUTE found on SOURCE class type member name MEMBERNAME
	/// where SOURCE is setup from factory into implementation
	/// </summary>
	/// <typeparam name="ATTRIBUTE"></typeparam>
	/// <typeparam name="VALUE"></typeparam>
	/// <param name="memberName"></param>
	/// <param name="action"></param>
	/// <returns></returns>
	IAttributeMapper Map<ATTRIBUTE, VALUE>(string memberName, Action<VALUE> action) where ATTRIBUTE : BaseValueAttribute<VALUE>;
}