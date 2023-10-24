namespace Cqrs;

public class CqrsDispatcher
{
	[Fact]
	public async Task _()
	{
		var ct = CancellationToken.None;
		var dispatcher = TestHost.Services.Get<ICqrsDispatcher>();
		var provider = new ValueProvider();
		var add1Cmd = new AddOneCommand(provider);
		var substract1Cmd = new SubstractOneCommand(provider);
		var providerValueQuery = new ValueProviderQuery(provider);
		var eventHandlerA = new EventA(provider);

		await dispatcher.RunCommandAsync(add1Cmd, ct);			// +1
		await dispatcher.RunCommandAsync(add1Cmd, ct);			// +1
		await dispatcher.RunCommandAsync(substract1Cmd, ct);	//-1
		await dispatcher.DispatchEventAsync(eventHandlerA, ct); // +3 & +5
		var actual = await dispatcher.RunQueryAsync(providerValueQuery, ct);
		Assert.Equal(expected: 1+1-1+3+5, actual: actual);
	}
}
