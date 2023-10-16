namespace Sygenic.CommonLib;

public sealed class SygenicProgram
{
  public static IHost? TryBuildHost(string[] args, string environmentalVariablePrefix = "SYGENIC_", Action<HostBuilderContext, IServiceCollection>? configureServices = null)
  {
    var host = Host
      .CreateDefaultBuilder(args)
      // methods of Host below listed in order of execution
      .ConfigureHostConfiguration(configurationBuilder =>
      {
      })
      .ConfigureAppConfiguration(builder =>
      {
        var cultureInfo = new CultureInfo((int)CultureTypes.NeutralCultures);
        var machineName = cultureInfo.TextInfo.ToTitleCase(Environment.MachineName);
        builder.AddJsonFile(path: "appsettings.json", optional: true, reloadOnChange: false);
        builder.AddJsonFile(path: $"appsettings.Machine.{machineName}.json", optional: true, reloadOnChange: false);
        builder.AddJsonFile(path: $"appsettings.User.{Environment.UserName}.json", optional: true, reloadOnChange: false);
        builder.AddEnvironmentVariables(environmentalVariablePrefix);
        builder.AddCommandLine(args); // program.exe -d VAR=val
      })
      .ConfigureLogging((hostingContext, builder) =>
      {
        builder.AddCyberConsole();
      })
      .ConfigureServices((context, services) =>
      {
        configureServices?.Invoke(context, services);
      })
      .Build();

    return host;
  }

  public static async Task<int> TryRunHostAsync(IHost host, CancellationToken cancellationToken)
  {
    try
    {
      await host.RunAsync(cancellationToken);
      return 0;
    }
    catch (TaskCanceledException)
    {
      System.Console.Error.WriteLine($"TaskCanceledException (Ctrl-C maybe), no proper software finish, error code 2");
      return 2;
    }
  }
}