namespace Cqrs;

public class CqrsDispatcher
{
	[Fact]
	public async Task _()
	{
		var dispatcher = TestHost.Services.Get<ICqrsDispatcher>();
		var provider = new Provider();
		var add1Cmd = new AddOneCommand(provider);
		var substract1Cmd = new SubstractOneCommand(provider);
		var providerValueQuery = new ProviderValueQuery(provider);
		var eventHandler1 = new Event3(provider);

		await dispatcher.ExecuteCommandAsync(add1Cmd, CancellationToken.None);
		await dispatcher.ExecuteCommandAsync(add1Cmd, CancellationToken.None);
		await dispatcher.ExecuteCommandAsync(substract1Cmd, CancellationToken.None);
		var actual = await dispatcher.ExecuteQueryAsync(providerValueQuery, CancellationToken.None);

		Assert.Equal(expected: 1, actual: actual);
	}
}
