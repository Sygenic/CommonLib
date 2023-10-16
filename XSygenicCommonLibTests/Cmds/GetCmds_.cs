namespace Cmds; 

public class GetCmds_
{
	[Fact]
	public void _()
	{
		var cmdProvider = X.Services.GetRequiredService<ICmdRegistry>();
		var cmds = cmdProvider.GetCmds("1, 1, addition, multiply");
		Assert.Equal(4, cmds.Count());
	}
}
