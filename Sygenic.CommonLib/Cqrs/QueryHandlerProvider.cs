namespace Sygenic.CommonLib;

internal sealed class QueryHandlerProvider : IQueryHandlerProvider
{
	private readonly IImplementationProvider implementationProvider;
	private readonly Lazy<MappingTypeToType> Mapping;

	public QueryHandlerProvider(IImplementationProvider implementationProvider)
	{
		this.implementationProvider = implementationProvider;
		Mapping = new(() => CreateMapping());
	}

	private static readonly string iQueryHandlerName = typeof(IQueryHandler<,>).Name;
	
	private MappingTypeToType CreateMapping()
	{
		var mapping = new MappingTypeToType();
		var handlerTypes = implementationProvider.GetTypesImplementingOrExtending(typeof(IQueryHandler<,>));
		foreach (var handlerType in handlerTypes)
		{
			var interfce = handlerType.GetInterface(iQueryHandlerName) 
				?? throw new ShouldNotBeHereException($"{iQueryHandlerName} not implemented");

			var genericArguments = interfce.GetGenericArguments();
			ShouldNotBeHereException.ThrowIf(genericArguments.Length != 2);
			mapping[genericArguments[0]] = handlerType;
		}
		return mapping;
	}

	public Type GetHandlerForQuery<TResponse>(IQuery<TResponse> query)
	{
		var queryType = query.GetType();
		if (Mapping.Value.TryGetValue(queryType, out var handlerType)) return handlerType;

		throw new NotImplementedException($"Handler for query {queryType} not found/registered/implemented");
	}
}