namespace Sygenic.CommonLib;

/// <summary>
/// Interface to (transient) service of bridge to System.Environment
/// </summary>
public interface IEnv
{
	string CommandLine { get; }
	string CurrentDirectory { get; set; }
	int CurrentManagedThreadId { get; }
	void Exit(int exitCode);
	int ExitCode { get; set; }
	bool HasShutdownStarted { get; }
	bool Is64BitOperatingSystem { get; }
	bool Is64BitProcess { get; }
	string[] GetCommandLineArgs();
	IDictionary GetEnvironmentVariables();
	string GetFolderPath(Environment.SpecialFolder folder, Environment.SpecialFolderOption option = Environment.SpecialFolderOption.None);
	string[] GetLogicalDrives();
	string MachineName { get; }
	string NewLine { get; }
	OperatingSystem OSVersion { get; }
	int ProcessId { get; }
	int ProcessorCount { get; }
	string? ProcessPath { get; }
	void SetEnvironmentVariable(string variable, string? value);
	string StackTrace { get; }
	string SystemDirectory { get; }
	int SystemPageSize { get; }
	int TickCount { get; }
	long TickCount64 { get; }
	string UserDomainName { get; }
	bool UserInteractive { get; }
	string UserName { get; }
	Version Version { get; }
	long WorkingSet { get; }

	/// <summary>
	/// Works from .net 8, does not work in .net7
	/// </summary>
	//bool IsPrivilegedProcess { get; }
}