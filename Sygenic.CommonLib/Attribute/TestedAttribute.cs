namespace Sygenic.CommonLib;

/// <summary>
/// Marks that method or class is TESTED or is so simple that tests are obvious or not needed.
/// If You change anything inside [Tested] method without test
/// than please change [Tested] to [NotTested] until You really test it. Also class containing [NotTested]
/// should be marked as [NotTested]
/// </summary>
[Tested]
[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
public sealed class TestedAttribute(params string[] infos) : BaseValueAttribute<string[]>(infos);