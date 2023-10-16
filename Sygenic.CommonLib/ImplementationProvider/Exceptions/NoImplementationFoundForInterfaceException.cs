namespace Sygenic.CommonLib;

[NotTested]
[Serializable]
internal sealed class NoImplementationFoundForInterfaceException : Exception
{
	private readonly Type InterfaceType;

	public NoImplementationFoundForInterfaceException(Type interfaceType) => InterfaceType = interfaceType;
}