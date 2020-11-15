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
            // Get a VISA.NET library version.
            Version VisaNetSharedComponentsVersion = typeof(GlobalResourceManager).Assembly.GetName().Version;
            Console.WriteLine("VISA.NET Shared Components version {0}.", VisaNetSharedComponentsVersion);

            // Check whether VISA Shared Components is installed before using VISA.NET.
            // If access VISA.NET without the visaConfMgr.dll library, an unhandled exception will
            // be thrown during termination process due to a bug in the implementation of the
            // VISA.NET Shared Components, andthe application will crash.
            FileVersionInfo VisaSharedComponentsInfo;
            try
            {
                // Get an available version of the VISA Shared Components.
                VisaSharedComponentsInfo = FileVersionInfo.GetVersionInfo(Path.Combine(Environment.SystemDirectory, "visaConfMgr.dll"));
                Console.WriteLine("VISA Shared Components version {0} detected.", VisaSharedComponentsInfo.ProductVersion);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("VISA implementation compatible with VISA.NET Shared Components {0} not found. Please install corresponding vendor-specific VISA implementation first.", VisaNetSharedComponentsVersion);
                return;
            }

            try
            {
                // Connect to the instrument.
                using (IVisaSession res = GlobalResourceManager.Open("TCPIP0::localhost::5025::SOCKET", AccessModes.ExclusiveLock, 2000))
                {
                    if (res is IMessageBasedSession session)
                    {
                        // Ensure termination character is enabled as here in example we use a SOCKET connection.
                        session.TerminationCharacterEnabled = true;

                        // Request information about an instrument.
                        session.FormattedIO.WriteLine("*IDN?");
                        string idn = session.FormattedIO.ReadLine();
                        Console.WriteLine("Instrument information: {0}", idn);
                    }
                    else
                    {
                        Console.WriteLine("Not a message-based session.");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is TypeInitializationException && ex.InnerException is DllNotFoundException)
                {
                    // VISA Shared Components is not installed.
                    Console.WriteLine("VISA implementation compatible with VISA.NET Shared Components {0} not found. Please install corresponding vendor-specific VISA implementation first.", VisaNetSharedComponentsVersion);
                }
                else if (ex is VisaException
                    && ex.Message == "No vendor-specific VISA .NET implementation is installed.")
                {
                    // Vendor-specific VISA.NET implementation is not available.
                    Console.WriteLine("VISA implementation compatible with VISA.NET Shared Components {0} not found. Please install corresponding vendor-specific VISA implementation first.", VisaNetSharedComponentsVersion);
                }
                else if (ex is EntryPointNotFoundException)
                {
                    // Installed VISA Shared Components is not compatible with VISA.NET Shared Components
                    Console.WriteLine("Installed VISA Shared Components version {0} does not support VISA.NET {1}. Please upgrade VISA implementation.", VisaSharedComponentsInfo.ProductVersion, VisaNetSharedComponentsVersion);
                }
                else
                {
                    // Handle remaining errors.
                    Console.WriteLine("Exception: {0}", ex.Message);
                }
            }

            Console.ReadKey();
        }
    }
}
