namespace Sygenic.CommonLib;

[NotTested]
[Serializable]
internal sealed class NoMemberFoundException : BaseIfException<NoMemberFoundException>
{
	public NoMemberFoundException()
	{
	}
}