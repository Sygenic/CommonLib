namespace Sygenic.CommonLib;

public interface IFreshServiceProvider
{
	T Get<T>(params object[] implementationsToUse) 
		where T : notnull;

	(T1, T2) Get<T1, T2>(params object[] implementationsToUse) 
		where T1 : notnull 
		where T2 : notnull;

	(T1, T2, T3) Get<T1, T2, T3>(params object[] implementationsToUse)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull;

	(T1, T2, T3, T4) Get<T1, T2, T3, T4>(params object[] implementationsToUse)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull;

	(T1, T2, T3, T4, T5) Get<T1, T2, T3, T4, T5>(params object[] implementationsToUse)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull;

	(T1, T2, T3, T4, T5, T6) Get<T1, T2, T3, T4, T5, T6>(params object[] implementationsToUse)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull;

	(T1, T2, T3, T4, T5, T6, T7) Get<T1, T2, T3, T4, T5, T6, T7>(params object[] implementationsToUse)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull;

	(T1, T2, T3, T4, T5, T6, T7, T8) Get<T1, T2, T3, T4, T5, T6, T7, T8>(params object[] implementationsToUse)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull;

	(T1, T2, T3, T4, T5, T6, T7, T8, T9) Get<T1, T2, T3, T4, T5, T6, T7, T8, T9>(params object[] implementationsToUse)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
		where T9 : notnull;

	(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10) Get<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(params object[] implementationsToUse)
		where T1 : notnull
		where T2 : notnull
		where T3 : notnull
		where T4 : notnull
		where T5 : notnull
		where T6 : notnull
		where T7 : notnull
		where T8 : notnull
		where T9 : notnull
		where T10 : notnull;
}