# SygenicCommonLib

## C# library implementing plugin system.

A command is some code that can be executed, has its own name and can be checked for ability to execute. 
To use commands append services with .TryAddSygenicCommonLib() on IServiceCollection instance, in which You can 
use optional parameter to append additional assemblies to scan for commands.

SygenicCommonLib provides a singleton ICmdRegistry which can return ICmd instance(s) by name(s)

## A command can be created in any of those ways:

1. Implement ICmd interface, so the implementation has its **static** Name, bool CanBeExecutedAsync and ExecuteAsync, with no context
2. Implement ICmd < CONTEXT > interface with a class acting as CONTEXT, so the implementation has two methods **more** - CanBeExecutedAsync(CONTEXT ctx)
and ExecuteAsync(CONTEXT ctx).
3. Use ICmdRegistry.RegisterLambdaCmd(...) and provide name, func to check if command can be executed and action called on commmand execution.

## Some additional notes

1. Commands (ICmd and ICmd<CONTEXT> implementations) are registered to IServiceCollection as transients
2. ICmd < CONTEXT > inherits ICmd and registering lambda cmd within ICmdRegistry also gives ICmd instance, so every command is an ICmd.
