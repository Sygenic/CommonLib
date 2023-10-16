namespace Sygenic.CommonLib;

[Tested]
public interface IAttributeMapperFactory
{
	IAttributeMapper Create<SOURCE_TYPE_WITH_ATTRIBUTES>();

	IAttributeMapper Create(Type sourceTypeWithAttributes);
}