namespace Sygenic.CommonLib;

/// <summary>
/// Finds implementation(s) for given type based on assemblies provided
/// </summary>
[NotTested]
public interface IImplementationProvider
{
	IEnumerable<Assembly> KnownAssembliesAsEnumerable();
	void PushCurrentDomainAssembliesToKnownAssemblies();
	void PushToKnownAssemblies(params Assembly[] assemblies);

	IEnumerable<Type> GetTypesImplementingOrExtending<T>();
	IEnumerable<Type> GetTypesImplementingOrExtending(Type type);
	IEnumerable<Type> GetInterfacesInheritedFrom(Type type);

	Type GetSingleTypeImplementingOrExtending(Type interfaceType);

	VALUE GetAttributeValue<VALUE, ATTRIBUTE>(MemberInfo member) where ATTRIBUTE : BaseValueAttribute<VALUE>;
	string GetStringAttributeValue<ATTRIBUTE>(Type type) where ATTRIBUTE : BaseValueAttribute<string>;
	bool HasAttribute<ATTRIBUTE>(MethodInfo methodInfo) where ATTRIBUTE : Attribute;
	IEnumerable<MethodInfo> GetMethodsHaving<ATTRIBUTE>(Type type) where ATTRIBUTE: Attribute;
}