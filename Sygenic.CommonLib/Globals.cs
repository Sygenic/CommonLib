global using System.Buffers.Text;
global using System.Collections;
global using System.Collections.Concurrent;
global using System.Collections.Frozen;
global using System.Collections.Immutable;
global using System.Collections.ObjectModel;
global using System.Diagnostics;
global using System.Drawing;
global using System.Globalization;
global using System.Reflection;
global using System.Runtime.InteropServices;
global using System.Runtime.Serialization;
global using System.Security.Cryptography;

global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Logging.Abstractions;
global using Microsoft.Extensions.Logging.Console;
global using Microsoft.Extensions.Options;

global using Pastel;

global using MappingTypeToType = System.Collections.Frozen.FrozenDictionary<System.Type, System.Type>;
global using MappingTypeToTypes = System.Collections.Frozen.FrozenDictionary<System.Type, System.Collections.Frozen.FrozenSet<System.Type>>;
global using Types = System.Collections.Generic.IEnumerable<System.Type>;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("XSygenicCommonLibTests")]