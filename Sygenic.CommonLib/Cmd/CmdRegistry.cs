namespace Sygenic.CommonLib;

[NotTested]
internal sealed class CmdRegistry : ICmdRegistry
{
	#region ctor DI
	
	private readonly IImplementationProvider implementationsProvider;

	public CmdRegistry(IImplementationProvider implementationsProvider)
	{
		this.implementationsProvider = implementationsProvider;
	}
	#endregion

	private readonly ConcurrentDictionary<string, LambdaCmd> LambdaSimpleCmds = new();

	private readonly ConcurrentDictionary<string, Type> CmdNameToCmdType = new();

	public void RegisterCmdsAsTransients(IServiceCollection services)
	{
		var implementations = implementationsProvider.GetTypesImplementingOrExtending(typeof(ICmd));
		foreach (var implementation in implementations)
		{
			var property = implementation.GetProperty(nameof(ICmd.Name), BindingFlags.Static | BindingFlags.Public) 
				?? throw new TypeNotImplementingICmdException(implementation);

			var cmdName = property.GetValue(null)?.ToString() ?? "";

			CmdNameToCmdType[cmdName] = implementation;
			services.TryAddTransient(implementation);
		}
	}

	public void RegisterLambdaCmd(string name, Func<bool> canExecute, Action execute)
			=> LambdaSimpleCmds[name] = new() { LambdaName = name, CanExecuteLambda = canExecute, ExecuteLambda = execute };

	/// <summary>
	/// Need to setup this field when IServiceProvider is built
	/// </summary>
	public IServiceProvider? serviceProvider;

	public ICmd GetCmd(string name)
	{
		ArgumentNullException.ThrowIfNull(serviceProvider);

		if (LambdaSimpleCmds.TryGetValue(name, out var value)) return value;

		if (CmdNameToCmdType.TryGetValue(name, out var type))
		{
			return serviceProvider.GetRequiredService(type) as ICmd ?? throw new TypeNotImplementingICmdException(name, type);
		}

		throw new CmdNotRegisteredException(name);
	}

	public IEnumerable<ICmd> GetCmds(string commaDelimitedCmdNames)
	{
		var ret = new List<ICmd>();
		foreach (var token in commaDelimitedCmdNames.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
		{
			ret.Add(GetCmd(token));
		}
		return ret;
	}

	/// <summary>
	/// Full args array with executable on [0] and command name on [1]
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentException"></exception>
	/// <exception cref="ShouldNotBeHereException"></exception>
  public ICmd<string[]> GetCmdByProgramArgs(string[] args)
  {
    if (args.Length < 2) throw new ArgumentException("Wrong number of arguments");
    var cmd = GetCmd(args[1]) as ICmd<string[]> ?? throw new ShouldNotBeHereException();
    return cmd;
  }
}