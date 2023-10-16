namespace Cmds;

public class BusinessClasses
{
	[Fact]
	public async Task _()
	{
		var cancellationToken = CancellationToken.None;
		var aSimpleCmd = new ASimpleCmd();
		var addCmd = new AdditionCmd();
		var additionContext = new AdditionContext { input = new int[] { 1, 2, 3 } };
		var multiplyCmd = new MultiplyCmd();
		var multiplyContext = new MultiplyContex { input = new int[] { 2, 3, 4 } };

		Assert.True(await aSimpleCmd.CanExecuteAsync(cancellationToken));
		await aSimpleCmd.ExecuteAsync(cancellationToken);

		Assert.True(await addCmd.CanExecuteAsync(cancellationToken));
		await addCmd.ExecuteAsync(cancellationToken);
		
		Assert.True(await addCmd.CanExecuteAsync(additionContext, cancellationToken));
		await addCmd.ExecuteAsync(additionContext, cancellationToken);
		Assert.Equal(6, additionContext.output);
		
		Assert.True(await multiplyCmd.CanExecuteAsync(cancellationToken));
		await multiplyCmd.ExecuteAsync(cancellationToken);
		
		Assert.True(await multiplyCmd.CanExecuteAsync(multiplyContext, cancellationToken));
		await multiplyCmd.ExecuteAsync(multiplyContext, cancellationToken);
		Assert.Equal(24, multiplyContext.output);
	}
}