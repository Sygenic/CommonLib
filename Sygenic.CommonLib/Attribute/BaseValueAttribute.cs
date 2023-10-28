namespace Sygenic.CommonLib;

/// <summary>
/// Base attribute class that contains property VALUE of type T
/// </summary>
/// <typeparam name="T"></typeparam>
[Tested("If AttributeMapper is tested than BaseValueAttribute<T> is tested")]
[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
public abstract class BaseValueAttribute<T> : Attribute
{
	public T Value { get; private set; }

	protected BaseValueAttribute(T value) => Value = value;
}