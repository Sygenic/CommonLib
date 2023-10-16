namespace AttributeMappers_.AttributeMapper;

public class Map
{
	[Fact]
	public void _()
	{
		var target = new TargetInstance();
		var mapperFactory = X.Services.Get<IAttributeMapperFactory>();
		var mapper = mapperFactory.Create<SourceClass>();
		mapper
				.Map<TestStringsSingleAttribute, string[]>(value => target.TestStringSingle = value)
				.Map<TODOAttribute, object[]>(value => target.Tudu = value)
				.Map<TODOAttribute, object[]>(nameof(SourceClass.Method), value => target.MethodTudu = value);

		Assert.Equal(new string[] { "one", "two" }, target.TestStringSingle);
		Assert.Equal(new string[] { "1", "2", "3" }, target.Tudu);
		Assert.Equal(new object[] { 1, 2, 3 }, target.MethodTudu);
	}

	[TestStringsSingle("one", "two")]
	[TODO("1", "2", "3")]
	class SourceClass
	{
		[TODO(1, 2, 3)]
		public static void Method()
		{
		}
	}

	class TargetInstance
	{
		public string[] TestStringSingle { get; set; } = Array.Empty<string>();
		public object[] Tudu { get; set; } = Array.Empty<object>();
		public object[] MethodTudu { get; set; } = Array.Empty<object>();
	}
}
