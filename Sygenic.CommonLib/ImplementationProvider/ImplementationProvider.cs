namespace Sygenic.CommonLib;

[NotTested]
internal sealed class ImplementationProvider : IImplementationProvider
{
	private readonly HashSet<Assembly> assemblyHashSet = new();

	public IEnumerable<Assembly> KnownAssembliesAsEnumerable() => assemblyHashSet.AsEnumerable();

	public void PushToKnownAssemblies(params Assembly[] assemblies)
	{
		foreach (var assembly in assemblies)
		{
			assemblyHashSet.Add(assembly);
		}
	}

	public void PushCurrentDomainAssembliesToKnownAssemblies() => PushToKnownAssemblies(AppDomain.CurrentDomain.GetAssemblies());

	public IEnumerable<Type> GetTypesImplementingOrExtending<T>() => GetTypesImplementingOrExtending(typeof(T));

	public IEnumerable<Type> GetTypesImplementingOrExtending(Type type)
	{
		var ret = new HashSet<Type>();
		foreach (var assembly in assemblyHashSet)
		{
			var types = assembly.GetTypes().Where(x => !x.IsAbstract && !x.IsInterface);
			foreach (var item in types)
			{
				if (item.IsAssignableTo(type) || item.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == type))
				{
					ret.Add(item);
				}
			}
		}
		return ret.AsEnumerable();
	}

	public IEnumerable<Type> GetInterfacesInheritedFrom(Type type)
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

	public Type GetSingleTypeImplementingOrExtending(Type interfaceType)
	{
		var implementationTypes = GetTypesImplementingOrExtending(interfaceType).ToList();
		if (implementationTypes.Count == 0)
		{
			throw new NoImplementationFoundForInterfaceException(interfaceType);
		}
		if (implementationTypes.Count > 1)
		{
			throw new MoreThanOneImplementationFoundForInterfaceException(interfaceType, implementationTypes);
		}
		return implementationTypes[0];
	}

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
}
