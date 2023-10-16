namespace Sygenic.CommonLib;

public interface IConsole
{
	void Write(string format, params object[] args);
	void WriteLine(string format, params object[] args);
	void Write(params object[] objs);
	void WriteLine(params object[] objs);
	IConsole Error { get; }
}
