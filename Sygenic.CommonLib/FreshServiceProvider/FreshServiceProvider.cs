namespace Sygenic.CommonLib;

public sealed class FreshServiceProvider(Action<IServiceCollection>? configureServices) : IFreshServiceProvider
{
	private ServiceProvider BuildProvider(object[] implementationsToUse)
	{
		var collection = new ServiceCollection();
		configureServices?.Invoke(collection);
		RegisterEveryImplementationAsSelfWithAllInterfacesAsSingleton(implementationsToUse, collection);
		var provider = collection.BuildServiceProvider();
		return provider;
	}

	private static void RegisterEveryImplementationAsSelfWithAllInterfacesAsSingleton(object[] implementationsToUse, ServiceCollection collection)
	{
		foreach (var implementation in implementationsToUse)
		{
			collection.AddSingleton(implementation);
			var type = implementation.GetType();
			var interfaces = type.GetInterfaces();
			foreach (var interfce in interfaces)
			{
				collection.AddSingleton(interfce, implementation);
			}
		}
	}

	public T Get<T>(params object[] implementationsToUse) 
		where T : notnull => BuildProvider(implementationsToUse).Get<T>();

	public (T1, T2) Get<T1, T2>(params object[] implementationsToUse)
		where T1 : notnull
		where T2 : notnull => BuildProvider(implementationsToUse).Get<T1, T2>();

	public (T1, T2, T3) Get<T1, T2, T3>(params object[] implementationsToUse)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull => BuildProvider(implementationsToUse).Get<T1, T2, T3>();

	public (T1, T2, T3, T4) Get<T1, T2, T3, T4>(params object[] implementationsToUse)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull => BuildProvider(implementationsToUse).Get<T1, T2, T3, T4>();

	public (T1, T2, T3, T4, T5) Get<T1, T2, T3, T4, T5>(params object[] implementationsToUse)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull => BuildProvider(implementationsToUse).Get<T1, T2, T3, T4, T5>();

	public (T1, T2, T3, T4, T5, T6) Get<T1, T2, T3, T4, T5, T6>(params object[] implementationsToUse)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull => BuildProvider(implementationsToUse).Get<T1, T2, T3, T4, T5, T6>();

	public (T1, T2, T3, T4, T5, T6, T7) Get<T1, T2, T3, T4, T5, T6, T7>(params object[] implementationsToUse)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull => throw new NotImplementedException();
	public (T1, T2, T3, T4, T5, T6, T7, T8) Get<T1, T2, T3, T4, T5, T6, T7, T8>(params object[] implementationsToUse)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull => BuildProvider(implementationsToUse).Get<T1, T2, T3, T4, T5, T6, T7, T8>();

	public (T1, T2, T3, T4, T5, T6, T7, T8, T9) Get<T1, T2, T3, T4, T5, T6, T7, T8, T9>(params object[] implementationsToUse)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
		where T9 : notnull => BuildProvider(implementationsToUse).Get<T1, T2, T3, T4, T5, T6, T7, T8, T9>();

	public (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10) Get<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(params object[] implementationsToUse)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
		where T9 : notnull
		where T10 : notnull => BuildProvider(implementationsToUse).Get<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>();
}
