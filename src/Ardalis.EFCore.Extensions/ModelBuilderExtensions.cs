using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Ardalis.EFCore.Extensions
{
    /// <summary>
    /// Original: https://stackoverflow.com/a/47263024/13729
    /// </summary>
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Applies all configurations defined in this assembly.
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="assembly"></param>
        /// <param name="configNamespace">Optional. If provided, only configurations in this namespace will be applied.</param>
        public static void ApplyAllConfigurationsFromCurrentAssembly(this ModelBuilder modelBuilder, Assembly assembly, string configNamespace = "")
        {
            var applyGenericMethods = typeof(ModelBuilder).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            var applyGenericApplyConfigurationMethods = applyGenericMethods.Where(m => m.IsGenericMethod && m.Name.Equals("ApplyConfiguration", StringComparison.OrdinalIgnoreCase));
            var applyGenericMethod = applyGenericApplyConfigurationMethods.Where(m => m.GetParameters().FirstOrDefault().ParameterType.Name == "IEntityTypeConfiguration`1").FirstOrDefault();


            var applicableTypes = assembly
                .GetTypes()
                .Where(c => c.IsClass && !c.IsAbstract && !c.ContainsGenericParameters);

            if (!string.IsNullOrEmpty(configNamespace))
            {
                applicableTypes = applicableTypes.Where(c => c.Namespace == configNamespace);
            }

            foreach (var type in applicableTypes)
            {
                foreach (var iface in type.GetInterfaces())
                {
                    // if type implements interface IEntityTypeConfiguration<SomeEntity>
                    if (iface.IsConstructedGenericType && iface.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    {
                        // make concrete ApplyConfiguration<SomeEntity> method
                        var applyConcreteMethod = applyGenericMethod.MakeGenericMethod(iface.GenericTypeArguments[0]);
                        // and invoke that with fresh instance of your configuration type
                        applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
                        Console.WriteLine("applied model " + type.Name);
                        break;
                    }
                }
            }
        }
    }
}
