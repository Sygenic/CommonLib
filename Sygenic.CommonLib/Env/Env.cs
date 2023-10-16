namespace Sygenic.CommonLib;

/// <summary>
/// Bridge to System.Environment (transient service)
/// </summary>
public class Env : IEnv
{
  public string CommandLine => Environment.CommandLine;
  public string CurrentDirectory { get => Environment.CurrentDirectory; set => Environment.CurrentDirectory = value; }
  public int CurrentManagedThreadId => Environment.CurrentManagedThreadId;
  public void Exit(int exitCode) => Environment.Exit(exitCode);
  public int ExitCode { get => Environment.ExitCode; set => Environment.ExitCode = value; }
  public bool HasShutdownStarted => Environment.HasShutdownStarted;
  public bool Is64BitOperatingSystem => Environment.Is64BitOperatingSystem;
  public bool Is64BitProcess => Environment.Is64BitProcess;
  
  public string[] GetCommandLineArgs() => Environment.GetCommandLineArgs();
  public IDictionary GetEnvironmentVariables() => Environment.GetEnvironmentVariables();
  public string GetFolderPath(Environment.SpecialFolder folder, Environment.SpecialFolderOption option = Environment.SpecialFolderOption.None) 
    => Environment.GetFolderPath(folder, option);

  public string[] GetLogicalDrives() => Environment.GetLogicalDrives();
  public string MachineName => Environment.MachineName;
  public string NewLine => Environment.NewLine;
  public OperatingSystem OSVersion => Environment.OSVersion;
  public int ProcessId => Environment.ProcessId;
  public int ProcessorCount => Environment.ProcessorCount;
  public string? ProcessPath { get; }
  public void SetEnvironmentVariable(string variable, string? value) => Environment.SetEnvironmentVariable(variable, value);
  public string StackTrace => Environment.StackTrace;
  public string SystemDirectory => Environment.SystemDirectory;
  public int SystemPageSize => Environment.SystemPageSize;
  public int TickCount => Environment.TickCount;
  public long TickCount64 => Environment.TickCount64;
  public string UserDomainName => Environment.UserDomainName;
  public bool UserInteractive => Environment.UserInteractive;
  public string UserName => Environment.UserName;
  public Version Version => Environment.Version;
  public long WorkingSet => Environment.WorkingSet;

  /// <summary>
  /// Works from .net 8, does not work in .net7
  /// </summary>
  //public bool IsPrivilegedProcess => Environment.IsPrivilegedProcess;
}