namespace Sygenic.CommonLib;

/// <summary>
/// Marks that class or method is NOT TESTED and should be TESTED ASAP
/// </summary>
[Tested]
[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
public sealed class NotTestedAttribute(params string[] infos) : BaseValueAttribute<string[]>(infos);