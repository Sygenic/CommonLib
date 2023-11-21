namespace Sygenic.CommonLib;

public sealed class NoAttributeFoundException<ATTRIBUTE>(object marketTarget) 
	: Exception($"No attribute {typeof(ATTRIBUTE)} found on {marketTarget}") where ATTRIBUTE : Attribute
{
	public readonly Type AttributeType = typeof(ATTRIBUTE);
	public readonly object MarkedTarget = marketTarget;
}