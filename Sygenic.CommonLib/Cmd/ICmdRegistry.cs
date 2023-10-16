namespace Sygenic.CommonLib;

/// <summary>
/// Singleton which provides any command(s) by name(s)
/// </summary>
[NotTested]
public interface ICmdRegistry
{
	/// <summary>
	/// Called during registration in SygenicCommandsLib.Extensions.TryAddSygenicCommands
	/// </summary>
	/// <param name="services"></param>
	void RegisterCmdsAsTransients(IServiceCollection services);

	/// <summary>
	/// To be called during runtime
	/// </summary>
	/// <param name="name"></param>
	/// <param name="canExecute"></param>
	/// <param name="execute"></param>
	void RegisterLambdaCmd(string name, Func<bool> canExecute, Action execute);

	ICmd GetCmd(string name);

	IEnumerable<ICmd> GetCmds(string commaDelimitedCmdNames);

	/// <summary>
	/// Full args array with executable on [0] and command name on [1]
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	ICmd<string[]> GetCmdByProgramArgs(string[] args);
}