namespace Sygenic.CommonLib;

[Tested]
public static class SygenicCommonLibExtensions
{
	/// <summary>
	/// Also runs IAssemblyProvider.PushCurrentDomainAssemblies
	/// </summary>
	/// <param name="services"></param>
	/// <param name="onImplementationProviderReady"></param>
	/// <returns></returns>
	public static IServiceCollection TryAddSygenicCommonLib(this IServiceCollection services, Action<IImplementationProvider>? onImplementationProviderReady = null)
	{
		services.TryAddSingleton<IPersistence, MemoryPersistence>();

		services.TryAddTransient<ISerializer, Serializer>();
		services.TryAddTransient<IPathResolver, PathResolver>();
		services.TryAddTransient<IColorConsoleHelper, ColorConsoleHelper>();
		services.TryAddTransient<IHelpFile, HelpFile>();
		services.TryAddTransient<IClock, Clock>();
		services.TryAddTransient<IEnv, Env>();
		services.TryAddTransient<IAttributeMapperFactory, AttributeMapperFactory>();
		services.TryAddTransient<ErrorConsole>();
		services.TryAddTransient<Console>();
		services.TryAddTransient<IConsole, Console>();
		services.TryAddTransient<IProcessExecutor, ProcessExecutor>();

		var implementationProvider = CreateAndConfigureImplementationsProvider(onImplementationProviderReady);
		services.TryAddSingleton<IImplementationProvider>(implementationProvider);

		var cmdRegistry = CreateAndConfigureCmdRegistry(services, implementationProvider);
		services.TryAddSingleton<ICmdRegistry>(serviceProvider =>
		{
			cmdRegistry.serviceProvider = serviceProvider;
			return cmdRegistry;
		});
		return services;
	}

	private static ImplementationProvider CreateAndConfigureImplementationsProvider(Action<IImplementationProvider>? onImplementationProviderReady)
	{
		var implementationProvider = new ImplementationProvider();
		
		implementationProvider.PushCurrentDomainAssembliesToKnownAssemblies();
		onImplementationProviderReady?.Invoke(implementationProvider);
		return implementationProvider;
	}

	private static CmdRegistry CreateAndConfigureCmdRegistry(IServiceCollection services, IImplementationProvider implementationProvider)
	{
		var registry = new CmdRegistry(implementationProvider);
		registry.RegisterCmdsAsTransients(services);
		return registry;
	}
}