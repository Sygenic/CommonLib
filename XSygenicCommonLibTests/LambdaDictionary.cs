namespace _;

public class DefaultDictionary
{
	[Fact]
	public void Default_lambda_is_called_when_no_key_found()
	{
		var dict = new LambdaDictionary<int, SomeDataA>
		{
			DefaultLambda = (key) => new SomeDataA { StringValue = $"{key}{key}" }
		};
		var newlyCreatedInstanceOfClass = dict[123];
		Assert.NotNull(newlyCreatedInstanceOfClass);
		Assert.IsType<SomeDataA>(newlyCreatedInstanceOfClass);
		Assert.Equal("123123", newlyCreatedInstanceOfClass.StringValue);
	}

	[Fact]
	public void Default_for_defaultLambda_is_to_create_new_instance_of_value()
	{
		var dict = new LambdaDictionary<string, SomeDataA>();
		var newlyCreatedInstanceOfClass = dict["there is no such key"];
		Assert.NotNull(newlyCreatedInstanceOfClass);
		Assert.IsType<SomeDataA>(newlyCreatedInstanceOfClass);
	}
}
