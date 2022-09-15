using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Ardalis.EFCore.Extensions;

/// <summary>
/// Original: https://stackoverflow.com/a/47263024/13729
/// </summary>
public static class ModelBuilderExtensions
{
	/// <summary>
	/// Applies all configurations defined in this assembly.
	/// </summary>
	/// <param name="modelBuilder"></param>
	/// <param name="assembly">Optional. The assembly in which the config classes are located.</param>
	/// <param name="configNamespace">Optional. If provided, only configurations in this namespace will be applied.</param>
	public static void ApplyAllConfigurationsFromCurrentAssembly(this ModelBuilder modelBuilder,
		Assembly? assembly = null, string configNamespace = "")
	{
		if (assembly == null) assembly = Assembly.GetCallingAssembly();
		modelBuilder.ApplyConfigurationsFromAssembly(assembly);
	}
}
