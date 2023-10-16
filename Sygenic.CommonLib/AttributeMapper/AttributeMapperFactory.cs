namespace Sygenic.CommonLib;

[Tested]
public sealed class AttributeMapperFactory : IAttributeMapperFactory
{
	public IAttributeMapper Create<SOURCE_TYPE_WITH_ATTRIBUTES>() => new AttributeMapper
	{ 
		SourceTypeMarkedWithAttributes = typeof(SOURCE_TYPE_WITH_ATTRIBUTES) 
	};

	public IAttributeMapper Create(Type sourceTypeWithAttributes) => new AttributeMapper
	{
		SourceTypeMarkedWithAttributes = sourceTypeWithAttributes
	};
}
