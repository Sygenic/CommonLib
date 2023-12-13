namespace Sygenic.CommonLib;

public sealed record ProcessOutcome(string Output, string Error, int ExitCode);