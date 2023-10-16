namespace XTests;

internal static class X
{
	internal static readonly IServiceProvider Services;

	static X()
	{
		var serviceCollection = new ServiceCollection();
		serviceCollection.TryAddSygenicCommonLib(implementationProvider => implementationProvider.PushToKnownAssemblies(typeof(X).Assembly));
		Services = serviceCollection.BuildServiceProvider();
	}
}