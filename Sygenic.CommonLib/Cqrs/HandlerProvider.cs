
namespace Sygenic.CommonLib;

internal sealed class HandlerProvider : IHandlerProvider
{
	private readonly IImplementationProvider implementationProvider;
	private readonly MappingTypeToType QueryMapping;
	private readonly MappingTypeToTypes EventMapping;

	public HandlerProvider(IImplementationProvider implementationProvider)
	{
		this.implementationProvider = implementationProvider;
		QueryMapping = CreateQueryMapping();
		EventMapping = CreateEventMapping();
	}

	private static readonly string IQUERYHANDLERNAME = typeof(IQueryHandler<,>).Name;
	private static readonly string IEVENTHANDLERNAME = typeof(IEventHandler<>).Name;
	
	private MappingTypeToType CreateQueryMapping()
	{
		var mapping = new MappingTypeToType();
		var handlerTypes = implementationProvider.GetTypesImplementingOrExtending(typeof(IQueryHandler<,>));
		foreach (var handlerType in handlerTypes)
		{
			var interfce = handlerType.GetInterface(IQUERYHANDLERNAME) 
				?? throw new ShouldNotBeHereException($"{IQUERYHANDLERNAME} not implemented");

			var genericArguments = interfce.GetGenericArguments();
			ShouldNotBeHereException.ThrowIf(genericArguments.Length != 2);
			mapping[genericArguments[0]] = handlerType;
		}
		return mapping;
	}

	private MappingTypeToTypes CreateEventMapping()
	{
		var mapping = new MappingTypeToTypes();
		var handlerTypes = implementationProvider.GetTypesImplementingOrExtending(typeof(IEventHandler<>));
		foreach (var handlerType in handlerTypes)
		{
			var interfce = handlerType.GetInterface(IEVENTHANDLERNAME)
				?? throw new ShouldNotBeHereException($"{IEVENTHANDLERNAME} not implemented");

			var genericArguments = interfce.GetGenericArguments();
			ShouldNotBeHereException.ThrowIf(genericArguments.Length != 1);
			var key = genericArguments[0];
			if (!mapping.ContainsKey(key))
			{
				mapping[key] = new HashSet<Type>();
			}
			mapping[key].Add(handlerType);
		}
		return mapping;
	}

	public Type GetQueryHandlerType<TResponse>(IQuery<TResponse> query)
	{
		var queryType = query.GetType();
		if (QueryMapping.TryGetValue(queryType, out var handlerType)) return handlerType;

		throw new NotImplementedException($"Handler for query {queryType} not found/registered/implemented");
	}

	public Types GetEventHandlerTypes(IEvent evnt)
	{
		var eventType = evnt.GetType();
		if (EventMapping.TryGetValue(eventType, out var handlerTypes)) return handlerTypes;
		throw new NotImplementedException($"Handler for event {eventType} not found/registered/implemented");
	}
}