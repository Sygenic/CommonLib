namespace Sygenic.CommonLib;

public class ErrorConsole : IConsole
{
	public IConsole Error => throw new NotImplementedException();

	public void Write(params object[] objs)
	{
		foreach (object obj in objs)
		{
			System.Console.Error.Write(obj);
		}
	}

	public void Write(string format, params object[] args) => System.Console.Error.Write(format, args);

	public void WriteLine(params object[] objs)
	{
		Write(objs);
		System.Console.Error.WriteLine();
	}

	public void WriteLine(string format, params object[] args) => System.Console.Error.WriteLine(format, args);
}
