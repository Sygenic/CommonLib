namespace Sygenic.CommonLib;

[NotTested]
[Serializable]
internal sealed class TypeNotImplementingICmdException : Exception
{
	internal readonly string CmdName;
	internal readonly Type CmdImplementationType;

	/// <summary>
	/// When property (ICmd.)Name is not found on command implementation
	/// </summary>
	/// <param name="cmdImplementationType"></param>
	public TypeNotImplementingICmdException(Type cmdImplementationType)
	{
		this.CmdImplementationType = cmdImplementationType;
		this.CmdName = "";
	}

	/// <summary>
	/// When command register under NAME as CMDIMPLEMENTATIONTYPE is not ICmd implementation
	/// </summary>
	/// <param name="name"></param>
	/// <param name="cmdImplementationType"></param>
	public TypeNotImplementingICmdException(string name, Type cmdImplementationType)
	{
		this.CmdName = name;
		this.CmdImplementationType = cmdImplementationType;
	}
}