namespace XTests;

/// <summary>
/// Test Host is used as a common shared configuration and services provider.
/// Usage of shared static TestHost could be seen as controversial.
/// On positive side usage of TestHost makes tests shorter and easier to write.
/// </summary>
internal static class TestHost
{
	internal static readonly IServiceProvider Services;

	static TestHost()
	{
		var services = new ServiceCollection();
		services.TryAddCqrs();
		services.TryAddSygenicCommonLib(implementationProvider 
			=> implementationProvider.PushToKnownAssemblies(typeof(TestHost).Assembly));
		Services = services.BuildServiceProvider();
	}
}