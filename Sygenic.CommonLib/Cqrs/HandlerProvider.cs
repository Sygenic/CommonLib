﻿namespace Sygenic.CommonLib;

internal sealed class HandlerProvider(IImplementationProvider implementationProvider) : IHandlerProvider
{
	private readonly MappingTypeToType QueryMapping = CreateQueryMapping(implementationProvider);
	private readonly MappingTypeToTypes EventMapping = CreateEventMapping(implementationProvider);

	private static MappingTypeToType CreateQueryMapping(IImplementationProvider implementationProvider)
	{
		var iQueryHandlerTypeName = typeof(IQueryHandler<,>).Name;
		var mapping = new Dictionary<Type, Type>();
		var handlerTypes = implementationProvider.GetTypesImplementingOrExtending(typeof(IQueryHandler<,>));
		foreach (var handlerType in handlerTypes)
		{
			var interfce = handlerType.GetInterface(iQueryHandlerTypeName) 
				?? throw new ShouldNotBeHereException($"{iQueryHandlerTypeName} is not implemented");

			var genericArguments = interfce.GetGenericArguments();
			ShouldNotBeHereException.ThrowIf(genericArguments.Length != 2, "Need exactly 2 generic arguments");
			mapping[genericArguments[0]] = handlerType;
		}
		return mapping.ToFrozenDictionary();
	}

	private static MappingTypeToTypes CreateEventMapping(IImplementationProvider implementationProvider)
	{
		var iEventHandlerTypeName = typeof(IEventHandler<>).Name;
		var mapping = new Dictionary<Type, HashSet<Type>>();
		var handlerTypes = implementationProvider.GetTypesImplementingOrExtending(typeof(IEventHandler<>));
		foreach (var handlerType in handlerTypes)
		{
			var interfce = handlerType.GetInterface(iEventHandlerTypeName)
				?? throw new ShouldNotBeHereException($"{iEventHandlerTypeName} is not implemented");

			var genericArguments = interfce.GetGenericArguments();
			ShouldNotBeHereException.ThrowIf(genericArguments.Length != 1, "Need exactly one generic argument");
			var key = genericArguments[0];
			if (!mapping.TryGetValue(key, out var value))
			{
				value = [];
				mapping[key] = value;
			}

			value.Add(handlerType);
		}
		var transformationDictionary = TransformValuesToFrozenSets(mapping);
		return transformationDictionary.ToFrozenDictionary();
	}

	

	public Type GetQueryHandlerType<TResponse>(IQuery<TResponse> query)
	{
		var queryType = query.GetType();
		if (QueryMapping.TryGetValue(queryType, out var handlerType)) return handlerType;

		throw new NotImplementedException($"Handler for query {queryType} not found/registered/implemented");
	}

	public Types GetEventHandlerTypes(IEvent evnt)
	{
		
	}
}