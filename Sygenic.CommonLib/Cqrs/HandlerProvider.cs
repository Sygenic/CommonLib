namespace Sygenic.CommonLib;

internal sealed class HandlerProvider(IImplementationProvider implementationProvider) : IHandlerProvider
{
	private readonly MappingTypeToType QueryMapping = CreateQueryMapping(implementationProvider);
	private readonly MappingTypeToTypes EventMapping = CreateEventMapping(implementationProvider);

	private static MappingTypeToType CreateQueryMapping(IImplementationProvider implementationProvider)
	{
		var iQueryHandlerTypeName = typeof(IQueryHandler<,>).Name;
		var mapping = new MappingTypeToType();
		var handlerTypes = implementationProvider.GetTypesImplementingOrExtending(typeof(IQueryHandler<,>));
		foreach (var handlerType in handlerTypes)
		{
			var interfce = handlerType.GetInterface(iQueryHandlerTypeName) 
				?? throw new ShouldNotBeHereException($"{iQueryHandlerTypeName} not implemented");

			var genericArguments = interfce.GetGenericArguments();
			ShouldNotBeHereException.ThrowIf(genericArguments.Length != 2);
			mapping[genericArguments[0]] = handlerType;
		}
		return mapping;
	}

	private static MappingTypeToTypes CreateEventMapping(IImplementationProvider implementationProvider)
	{
		var iEventHandlerTypeName = typeof(IEventHandler<>).Name;
		var mapping = new MappingTypeToTypes();
		var handlerTypes = implementationProvider.GetTypesImplementingOrExtending(typeof(IEventHandler<>));
		foreach (var handlerType in handlerTypes)
		{
			var interfce = handlerType.GetInterface(iEventHandlerTypeName)
				?? throw new ShouldNotBeHereException($"{iEventHandlerTypeName} not implemented");

			var genericArguments = interfce.GetGenericArguments();
			ShouldNotBeHereException.ThrowIf(genericArguments.Length != 1);
			var key = genericArguments[0];
			if (!mapping.TryGetValue(key, out var value))
			{
				value = [];
				mapping[key] = value;
			}

			value.Add(handlerType);
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