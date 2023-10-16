namespace XTests;

public class LamdaCmd_
{
	[Fact]
	public async Task _()
	{
		var wasExecuted = false;

		var lambda = new LambdaCmd
		{
			LambdaName = "foo",
			CanExecuteLambda = () => true,
			ExecuteLambda = () => wasExecuted = true
		};

		var cancellationToken = CancellationToken.None;
		Assert.True(await lambda.CanExecuteAsync(cancellationToken));
		await lambda.ExecuteAsync(cancellationToken);
		Assert.True(wasExecuted);
	}
}