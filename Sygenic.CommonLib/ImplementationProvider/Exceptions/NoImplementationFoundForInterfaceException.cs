namespace Sygenic.CommonLib;

[Serializable]
internal sealed class NoImplementationFoundForInterfaceException(Type interfaceType) : Exception
{
	public readonly Type InterfaceType = interfaceType;
}