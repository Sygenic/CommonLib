namespace Sygenic.CommonLib;

[NotTested]
[Serializable]
public sealed class NoAttributeFoundException<ATTRIBUTE> : Exception where ATTRIBUTE : Attribute
{
	public readonly Type AttributeType = typeof(ATTRIBUTE);
	public readonly object MarkedTarget;

	public NoAttributeFoundException(object marketTarget) : base($"No attribute {typeof(ATTRIBUTE)} found on {marketTarget}")
	{
		AttributeType = typeof(ATTRIBUTE);
		MarkedTarget = marketTarget;
	}
}