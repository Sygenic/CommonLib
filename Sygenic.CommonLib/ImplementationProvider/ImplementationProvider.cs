namespace Sygenic.CommonLib;

internal sealed class ImplementationProvider : IImplementationProvider
{
	private readonly HashSet<Assembly> assemblyHashSet = [];

	public IEnumerable<Assembly> KnownAssembliesAsEnumerable() => assemblyHashSet.AsEnumerable();

	public Types GetInterfacesInheritedFrom(Type type)
	{
		var ret = new HashSet<Type>();
		foreach (var assembly in assemblyHashSet)
		{
			var interfaces = assembly.GetTypes().Where(t => t.IsInterface && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == type));

			foreach (var item in interfaces)
			{
				ret.Add(item);
			}
		}
		return ret.AsEnumerable();
	}

	public string GetStringAttributeValue<ATTRIBUTE>(Type type) where ATTRIBUTE : BaseValueAttribute<string>
		=> type.GetCustomAttribute<ATTRIBUTE>(inherit: true)?.Value ?? throw new NoAttributeFoundException<ATTRIBUTE>(type);

	public bool HasAttribute<ATTRIBUTE>(MethodInfo methodInfo) where ATTRIBUTE : Attribute
	{
		var customAttribute = methodInfo.GetCustomAttribute<ATTRIBUTE>(inherit: true);
		return (customAttribute is not null);
	}

	public IEnumerable<MethodInfo> GetMethodsHaving<ATTRIBUTE>(Type type) where ATTRIBUTE : Attribute
		=> type.GetMethods().Where(x => x.GetCustomAttribute<ATTRIBUTE>() != null);

	public VALUE GetAttributeValue<VALUE, ATTRIBUTE>(MemberInfo member) where ATTRIBUTE : BaseValueAttribute<VALUE>
	{
		var attribute = member.GetCustomAttribute<ATTRIBUTE>(inherit: true) ?? throw new NoAttributeFoundException<ATTRIBUTE>(member);
		return attribute.Value;
	}

	public Types GetTypesImplementingOrExtending(Type type) => throw new NotImplementedException();
}
