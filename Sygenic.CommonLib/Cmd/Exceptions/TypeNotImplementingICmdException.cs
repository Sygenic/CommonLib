namespace Sygenic.CommonLib;

/// <summary>
/// When command register under NAME as CMDIMPLEMENTATIONTYPE is not ICmd implementation
/// </summary>
/// <param name="name"></param>
/// <param name="cmdImplementationType"></param>
public sealed class TypeNotImplementingICmdException(Type cmdImplementationType, string? name = "") : Exception
{
	public readonly string? CmdName = name;
	public readonly Type CmdImplementationType = cmdImplementationType;
}