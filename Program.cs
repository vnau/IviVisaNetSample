using Ivi.Visa;
using System;
using System.Diagnostics;
using System.IO;

namespace IviVisaNetSample
{
    static class Program
    {
        static void Main()
        {
            // Get VISA.NET Shared Components version.
            Version visaNetSharedComponentsVersion = typeof(GlobalResourceManager).Assembly.GetName().Version;
            Console.WriteLine($"VISA.NET Shared Components version {visaNetSharedComponentsVersion}.");

            // Check whether VISA Shared Components is installed before using VISA.NET.
            // If access VISA.NET without the visaConfMgr.dll library, an unhandled exception will
            // be thrown during termination process due to a bug in the implementation of the
            // VISA.NET Shared Components, andthe application will crash.
            try
            {
                // Get an available version of the VISA Shared Components.
                FileVersionInfo visaSharedComponentsInfo = FileVersionInfo.GetVersionInfo(Path.Combine(Environment.SystemDirectory, "visaConfMgr.dll"));
                Console.WriteLine($"VISA Shared Components version {visaSharedComponentsInfo.ProductVersion} detected.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"VISA implementation compatible with VISA.NET Shared Components {visaNetSharedComponentsVersion} not found. Please install corresponding vendor-specific VISA implementation first.");
                return;
            }

#if NET5_0_OR_GREATER
            // Preloading installed VISA implementation assemblies for NET 5+
            GacLoader.LoadInstalledVisaAssemblies();
#endif

            try
            {
                // Connect to the instrument.
                var resourceName = "TCPIP::localhost::5025::SOCKET";
                using (IVisaSession resource = GlobalResourceManager.Open(resourceName, AccessModes.ExclusiveLock, 2000))
                {
                    if (resource is IMessageBasedSession session)
                    {
                        // Ensure termination character is enabled as here in example we use a SOCKET connection.
                        session.TerminationCharacterEnabled = true;

                        // Request information about an instrument.
                        session.FormattedIO.WriteLine("*IDN?");
                        string instrumentInfo = session.FormattedIO.ReadLine();
                        Console.WriteLine($"Instrument information: {instrumentInfo}");
                    }
                    else
                    {
                        Console.WriteLine("Not a message-based session.");
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception is TypeInitializationException && exception.InnerException is DllNotFoundException)
                {
                    // VISA Shared Components is not installed.
                    Console.WriteLine($"VISA implementation compatible with VISA.NET Shared Components {visaNetSharedComponentsVersion} not found. Please install corresponding vendor-specific VISA implementation first.");
                }
                else if (exception is VisaException && exception.Message == "No vendor-specific VISA .NET implementation is installed.")
                {
                    // Vendor-specific VISA.NET implementation is not available.
                    Console.WriteLine($"VISA implementation compatible with VISA.NET Shared Components {visaNetSharedComponentsVersion} not found. Please install corresponding vendor-specific VISA implementation first.");
                }
                else if (exception is EntryPointNotFoundException)
                {
                    // Installed VISA Shared Components are not compatible with VISA.NET Shared Components.
                    Console.WriteLine($"Installed VISA Shared Components version {visaNetSharedComponentsVersion} does not support VISA.NET. Please upgrade VISA implementation.");
                }
                else
                {
                    // Handle remaining errors.
                    Console.WriteLine($"Exception: {exception.Message}");
                }
            }

            Console.ReadKey();
        }
    }
}
