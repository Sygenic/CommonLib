namespace Sygenic.CommonLib;

public class Console : IConsole
{
	#region ctor DI
	private readonly ErrorConsole errorConsole;
	public Console(ErrorConsole errorConsole)
	{
		this.errorConsole = errorConsole;
	}
	#endregion

	public IConsole Error => errorConsole;

	public void Write(params object[] objs)
	{
		foreach (object obj in objs)
		{
			System.Console.Write(obj);
		}
	}

	public void Write(string format, params object[] args) => System.Console.Write(format, args);

	public void WriteLine(params object[] objs)
	{
		Write(objs);
		System.Console.WriteLine();
	}

	public void WriteLine(string format, params object[] args) => System.Console.WriteLine(format, args);
}
