namespace Cmds; 

public class GetCmdByProgramArgs
{
	[Fact]
	public void _()
	{
		var cmdProvider = TestHost.Services.GetRequiredService<ICmdRegistry>();
		var cmd = cmdProvider.GetCmdByProgramArgs(
		[
			"here is arg0 - command line executable, next is cmd name", 
			"ArgCmdWithStringArr" 
		]);
		Assert.IsType<ArgCmdWithStringArr>(cmd);
	}
}
