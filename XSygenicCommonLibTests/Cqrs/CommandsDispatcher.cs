namespace Cqrs;

public class CommandsDispatcher
{
	[Fact]
	public async Task _()
	{
		var cmdDispatcher = TestHost.Services.Get<ICommandDispatcher>();
		var provider = new Provider();

		var addCmd = new AddOneCommand(provider);
		await cmdDispatcher.ExecuteCommandAsync(addCmd, CancellationToken.None);
		await cmdDispatcher.ExecuteCommandAsync(addCmd, CancellationToken.None);

		var subCmd = new SubstractOneCommand(provider);
		await cmdDispatcher.ExecuteCommandAsync(subCmd, CancellationToken.None);

		Assert.Equal(expected: 1, actual: provider.Value);
	}
}
