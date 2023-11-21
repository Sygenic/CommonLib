﻿namespace Sygenic.CommonLib;

internal sealed class MoreThanOneImplementationFoundForInterfaceException(
	Type interfaceType, 
	List<Type> implementationTypes) : Exception
{
	public readonly Type InterfaceType = interfaceType;
	public readonly List<Type> ImplementationTypes = implementationTypes;
}