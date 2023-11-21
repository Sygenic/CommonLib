namespace Sygenic.CommonLib;

/// <summary>
/// Marks any TODO information in more informative way than TODO comment
/// </summary>
[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
public class TODOAttribute(params object[] values) : BaseValueAttribute<object[]>(values);