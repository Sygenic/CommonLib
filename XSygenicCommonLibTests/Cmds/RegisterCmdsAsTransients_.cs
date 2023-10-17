namespace Cmds;

public class RegisterCmdsAsTransients_
{
	[Fact]
	public void _()
	{
		TestHost.Services.GetRequiredService<ASimpleCmd>();
		TestHost.Services.GetRequiredService<AdditionCmd>();
	}
}