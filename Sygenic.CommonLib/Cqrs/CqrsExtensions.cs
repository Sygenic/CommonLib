namespace Sygenic.CommonLib;

public static class CqrsExtensions
{
	public static IServiceCollection TryAddCqrs(this IServiceCollection services)
	{
		services.TryAddSingleton<IHandlerProvider, HandlerProvider>();
		services.TryAddTransient<ICqrsDispatcher, CqrsDispatcher>();

		services.Scan(x => x
			.FromApplicationDependencies()
			.AddClasses(x => x.AssignableTo(typeof(IQueryHandler<,>)))
			.AsSelfWithInterfaces()
			.WithTransientLifetime());

		services.Scan(x => x
			.FromApplicationDependencies()
			.AddClasses(x => x.AssignableTo(typeof(ICommandHandler<>)))
			.AsSelfWithInterfaces()
			.WithTransientLifetime());

		services.Scan(x => x
			.FromApplicationDependencies()
			.AddClasses(x => x.AssignableTo(typeof(IEventHandler<>)))
			.AsSelf() // just as selfs!
			.WithTransientLifetime());

		return services;
	}
}