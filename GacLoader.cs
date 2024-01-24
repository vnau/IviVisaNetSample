using Ivi.Visa.ConflictManager;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace IviVisaNetSample
{
#if NET5_0_OR_GREATER
    /// <summary>
    /// Class used to load .NET Framework assemblies located in GAC from .NET 5+
    /// Requred only for expiremental using VISA.NET library in .NET 5+
    /// </summary>
    internal static class GacLoader
    {
        /// <summary>
        /// Load an assembly from the GAC.
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns>Loaded assembly</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static Assembly Load(AssemblyName assemblyName)
        {
            var gacPaths = new[]
            {
               $"{Environment.GetFolderPath(Environment.SpecialFolder.Windows)}\\Microsoft.NET\\assembly\\GAC_MSIL\\{assemblyName.Name}",
               $"{Environment.GetFolderPath(Environment.SpecialFolder.Windows)}\\assembly\\GAC_MSIL\\{assemblyName.Name}",
            };

            foreach (var folder in gacPaths.Where(f => Directory.Exists(f)))
            {
                foreach (var subfolder in Directory.EnumerateDirectories(folder))
                {
                    if (subfolder.Contains(Convert.ToHexString(assemblyName.GetPublicKeyToken()), StringComparison.OrdinalIgnoreCase)
                        && subfolder.Contains(assemblyName.Version.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        var assemblyPath = Path.Combine(subfolder, assemblyName.Name + ".dll");
                        if (File.Exists(assemblyPath))
                            return Assembly.LoadFrom(assemblyPath);
                    }
                }
            }
            throw new FileNotFoundException($"Assembly {assemblyName} not found.");
        }

        /// <summary>
        /// Preloading installed VISA implementation assemblies for NET 5+
        /// </summary>
        public static void LoadInstalledVisaAssemblies() {
            var installedVisas = new ConflictManager().GetInstalledVisas(ApiType.DotNet);
            foreach (var visaLibrary in installedVisas)
            {
                try
                {
                    var inst = GacLoader.Load(new AssemblyName(visaLibrary.Location.Substring(visaLibrary.Location.IndexOf(",") + 1)));
                    Console.WriteLine($"Loaded assembly \"{visaLibrary.FriendlyName}\".");
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Failed to load assembly \"{visaLibrary.FriendlyName}\": {exception.Message}");
                }
            }
        }
    }
#endif
}
