namespace _Helpers;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class TestStringsSingleAttribute(params string[] values) : BaseValueAttribute<string[]>(values);