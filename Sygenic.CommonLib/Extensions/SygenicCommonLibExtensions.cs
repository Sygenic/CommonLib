namespace Sygenic.CommonLib;

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

		services.TryAddTransient<IPathResolver, PathResolver>();
		services.TryAddTransient<IColorConsoleHelper, ColorConsoleHelper>();
		services.TryAddTransient<IHelpFile, HelpFile>();
		services.TryAddTransient<IEnvironment, Environment>();
		services.TryAddTransient<IAttributeMapperFactory, AttributeMapperFactory>();
		services.TryAddTransient<ErrorConsole>();
		services.TryAddTransient<Console>();
		services.TryAddTransient<IConsole, Console>();
		services.TryAddTransient<IProcessExecutor, ProcessExecutor>();

		return services;
	}
}