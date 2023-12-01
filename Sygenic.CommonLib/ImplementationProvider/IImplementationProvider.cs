namespace Sygenic.CommonLib;

/// <summary>
/// Finds implementation(s) for given type based on assemblies provided
/// </summary>
public interface IImplementationProvider
{
    Types GetInterfacesInheritedFrom(Type type);

	VALUE GetAttributeValue<VALUE, ATTRIBUTE>(MemberInfo member) where ATTRIBUTE : BaseValueAttribute<VALUE>;
	string GetStringAttributeValue<ATTRIBUTE>(Type type) where ATTRIBUTE : BaseValueAttribute<string>;
	bool HasAttribute<ATTRIBUTE>(MethodInfo methodInfo) where ATTRIBUTE : Attribute;
	IEnumerable<MethodInfo> GetMethodsHaving<ATTRIBUTE>(Type type) where ATTRIBUTE: Attribute;
	Types GetTypesImplementingOrExtending(Type type);
}