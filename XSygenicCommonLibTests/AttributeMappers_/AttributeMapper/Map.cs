namespace AttributeMappers_.AttributeMapper;

public class Map
{
	private static readonly string[] expected = ["one", "two"];
	private static readonly string[] expectedArray = ["1", "2", "3"];

	[Fact]
	public void _()
	{
		var target = new TargetInstance();
		var mapperFactory = TestHost.Services.Get<IAttributeMapperFactory>();
		var mapper = mapperFactory.Create<SourceClass>();
		mapper
				.Map<TestStringsSingleAttribute, string[]>(value => target.TestStringSingle = value)
				.Map<TODOAttribute, object[]>(value => target.Tudu = value)
				.Map<TODOAttribute, object[]>(nameof(SourceClass.Method), value => target.MethodTudu = value);

		Assert.Equal(expected, target.TestStringSingle);
		Assert.Equal(expectedArray, target.Tudu);
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
		public string[] TestStringSingle { get; set; } = [];
		public object[] Tudu { get; set; } = [];
		public object[] MethodTudu { get; set; } = [];
	}
}
