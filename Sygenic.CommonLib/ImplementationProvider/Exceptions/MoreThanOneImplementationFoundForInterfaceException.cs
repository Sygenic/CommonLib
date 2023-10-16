namespace Sygenic.CommonLib;

[NotTested]
[Serializable]
internal sealed class MoreThanOneImplementationFoundForInterfaceException : Exception
{
	private Type? interfaceType;
	private List<Type> implementationTypes = new();

	public MoreThanOneImplementationFoundForInterfaceException(Type interfaceType, List<Type> implementationTypes)
	{
		this.interfaceType = interfaceType;
		this.implementationTypes = implementationTypes;
	}
}