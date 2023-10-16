namespace Sygenic.CommonLib;

[Tested]
public static class ServiceProviderGetExtensions
{
	public static T Get<T>(this IServiceProvider provider) 
		where T : notnull 
		=> provider.GetRequiredService<T>();

	public static (T1, T2) Get<T1, T2>(this IServiceProvider provider)
		where T1 : notnull 
		where T2 : notnull 
		=> (provider.Get<T1>(), provider.Get<T2>());

	public static (T1, T2, T3) Get<T1, T2, T3>(this IServiceProvider provider) 
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		=> (provider.Get<T1>(), provider.Get<T2>(), provider.Get<T3>());

	public static (T1, T2, T3, T4) Get<T1, T2, T3, T4>(this IServiceProvider provider)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		=> (provider.Get<T1>(), provider.Get<T2>(), provider.Get<T3>(), provider.Get<T4>());

	public static (T1, T2, T3, T4, T5) Get<T1, T2, T3, T4, T5>(this IServiceProvider provider)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		=> (provider.Get<T1>(), provider.Get<T2>(), provider.Get<T3>(), provider.Get<T4>(), provider.Get<T5>());

	public static (T1, T2, T3, T4, T5, T6) Get<T1, T2, T3, T4, T5, T6>(this IServiceProvider provider)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		=> (provider.Get<T1>(), provider.Get<T2>(), provider.Get<T3>(), provider.Get<T4>(), provider.Get<T5>(), provider.Get<T6>());

	public static (T1, T2, T3, T4, T5, T6, T7) Get<T1, T2, T3, T4, T5, T6, T7>(this IServiceProvider provider)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		=> (provider.Get<T1>(), provider.Get<T2>(), provider.Get<T3>(), provider.Get<T4>(), provider.Get<T5>(), provider.Get<T6>(), provider.Get<T7>());

	public static (T1, T2, T3, T4, T5, T6, T7, T8) Get<T1, T2, T3, T4, T5, T6, T7, T8>(this IServiceProvider provider)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
		=> (provider.Get<T1>(), provider.Get<T2>(), provider.Get<T3>(), provider.Get<T4>(), provider.Get<T5>(), provider.Get<T6>(), provider.Get<T7>(), provider.Get<T8>());

	public static (T1, T2, T3, T4, T5, T6, T7, T8, T9) Get<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IServiceProvider provider)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
		where T9 : notnull
		=> (provider.Get<T1>(), provider.Get<T2>(), provider.Get<T3>(), provider.Get<T4>(), provider.Get<T5>(), provider.Get<T6>(), provider.Get<T7>(), provider.Get<T8>(), provider.Get<T9>());

	public static (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10) Get<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IServiceProvider provider)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
		where T9 : notnull
		where T10 : notnull
		=> (provider.Get<T1>(), provider.Get<T2>(), provider.Get<T3>(), provider.Get<T4>(), provider.Get<T5>(), provider.Get<T6>(), provider.Get<T7>(), provider.Get<T8>(), provider.Get<T9>(), provider.Get<T10>());
}
