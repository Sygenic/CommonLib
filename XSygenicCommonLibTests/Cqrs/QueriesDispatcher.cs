namespace Cqrs;

public class QueriesDispatcher
{
	[Fact]
	public async Task _()
	{
		var queryDispatcher = TestHost.Services.Get<ICqrsDispatcher>();

		var input = "Hello world I am Jan B!";
		var query = new EchoQuery(input);

		var response = await queryDispatcher.ExecuteQueryAsync(query, CancellationToken.None);
		Assert.Equal(expected: $"{input} {input}", actual: response);
	}
}