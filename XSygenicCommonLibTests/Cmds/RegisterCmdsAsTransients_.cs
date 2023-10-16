namespace Cmds;

public class RegisterCmdsAsTransients_
{
	[Fact]
	public void _()
	{
		X.Services.GetRequiredService<ASimpleCmd>();
		X.Services.GetRequiredService<AdditionCmd>();
	}
}