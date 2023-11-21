namespace Sygenic.CommonLib;

internal sealed class AttributeMapper : IAttributeMapper
{
	internal AttributeMapper()
	{
	}

	public required Type SourceTypeMarkedWithAttributes { get; init; }

	public IAttributeMapper Map<ATTRIBUTE, VALUE>(Action<VALUE> action) where ATTRIBUTE : BaseValueAttribute<VALUE>
	{
		ATTRIBUTE customAttribute = SourceTypeMarkedWithAttributes.GetCustomAttribute<ATTRIBUTE>(inherit: true)
			?? throw new NoAttributeFoundException<ATTRIBUTE>(SourceTypeMarkedWithAttributes);

		action(customAttribute.Value);
		
		return this;
	}

	public IAttributeMapper Map<ATTRIBUTE, VALUE>(string memberName, Action<VALUE> action) where ATTRIBUTE: BaseValueAttribute<VALUE>
	{
		var srcType = SourceTypeMarkedWithAttributes;
		var members = srcType.GetMember(memberName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
			| BindingFlags.Static | BindingFlags.FlattenHierarchy);

		NoMemberFoundException.ThrowIf(members.Length == 0);
		TooManyMembersFoundException.ThrowIf(members.Length > 1);

		var member = members[0];
		ATTRIBUTE customAttribute = member.GetCustomAttribute<ATTRIBUTE>(inherit: true)	
			?? throw new NoAttributeFoundException<ATTRIBUTE>(member);

		action(customAttribute.Value);

		return this;
	}
}