namespace Cmds; 

public class GetCmdByProgramArgs
{
	[Fact]
	public void _()
	{
		var cmdProvider = X.Services.GetRequiredService<ICmdRegistry>();
		var cmd = cmdProvider.GetCmdByProgramArgs(new string[] 
		{ 
			"here is arg0 - command line executable, next is cmd name", 
			"ArgCmdWithStringArr" 
		});
		Assert.IsType<ArgCmdWithStringArr>(cmd);
	}
}
