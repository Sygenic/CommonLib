namespace Sygenic.CommonLib;

/// <summary>
/// Bridge to System.Environment (transient service)
/// </summary>
internal sealed class Environment : IEnvironment
{
  public string CommandLine => System.Environment.CommandLine;
  public string CurrentDirectory { get => System.Environment.CurrentDirectory; set => System.Environment.CurrentDirectory = value; }
  public int CurrentManagedThreadId => System.Environment.CurrentManagedThreadId;
  public void Exit(int exitCode) => System.Environment.Exit(exitCode);
  public int ExitCode { get => System.Environment.ExitCode; set => System.Environment.ExitCode = value; }
  public bool HasShutdownStarted => System.Environment.HasShutdownStarted;
  public bool Is64BitOperatingSystem => System.Environment.Is64BitOperatingSystem;
  public bool Is64BitProcess => System.Environment.Is64BitProcess;
  
  public string[] GetCommandLineArgs() => System.Environment.GetCommandLineArgs();
  public IDictionary GetEnvironmentVariables() => System.Environment.GetEnvironmentVariables();
  public string GetFolderPath(System.Environment.SpecialFolder folder, System.Environment.SpecialFolderOption option = System.Environment.SpecialFolderOption.None) 
    => System.Environment.GetFolderPath(folder, option);

  public string[] GetLogicalDrives() => System.Environment.GetLogicalDrives();
  public string MachineName => System.Environment.MachineName;
  public string NewLine => System.Environment.NewLine;
  public OperatingSystem OSVersion => System.Environment.OSVersion;
  public int ProcessId => System.Environment.ProcessId;
  public int ProcessorCount => System.Environment.ProcessorCount;
  public string? ProcessPath { get; }
  public void SetEnvironmentVariable(string variable, string? value) => System.Environment.SetEnvironmentVariable(variable, value);
  public string StackTrace => System.Environment.StackTrace;
  public string SystemDirectory => System.Environment.SystemDirectory;
  public int SystemPageSize => System.Environment.SystemPageSize;
  public int TickCount => System.Environment.TickCount;
  public long TickCount64 => System.Environment.TickCount64;
  public string UserDomainName => System.Environment.UserDomainName;
  public bool UserInteractive => System.Environment.UserInteractive;
  public string UserName => System.Environment.UserName;
  public Version Version => System.Environment.Version;
  public long WorkingSet => System.Environment.WorkingSet;

  /// <summary>
  /// Works from .net 8, does not work in .net7
  /// </summary>
  public bool IsPrivilegedProcess => System.Environment.IsPrivilegedProcess;
}