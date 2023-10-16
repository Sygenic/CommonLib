namespace Sygenic.CommonLib;

/// <summary>
/// Base class that contains property VALUE of given type T
/// </summary>
/// <typeparam name="T"></typeparam>
[Tested("If AttributeMapper is tested than BaseValueAttribute<T> is tested")]
[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
public abstract class BaseValueAttribute<T> : Attribute
{
	public T Value { get; private set; }

	protected BaseValueAttribute(T value) => Value = value;
}