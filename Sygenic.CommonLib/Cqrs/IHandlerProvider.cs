﻿namespace Sygenic.CommonLib;

public interface IHandlerProvider
{
	Type GetQueryHandlerType<R>(IQuery<R> query);
	Types GetEventHandlerTypes(IEvent evnt);
}