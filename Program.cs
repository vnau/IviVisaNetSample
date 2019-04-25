using Ivi.Visa;
using System;
using System.Diagnostics;

namespace IviVisaNetSample
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var res = GlobalResourceManager.Open("TCPIP:localhost::inst0::INSTR"))
                {
                    if (res is IMessageBasedFormattedIO session)
                    {
                        session.WriteLine("*IDN?");
                        var idn = session.ReadLine();
                        Console.WriteLine("Connected to {0}", idn);
                    }
                }
            }
            catch (TypeInitializationException ex)
            {
                if (ex.InnerException != null && ex.InnerException is DllNotFoundException)
                {
                    var VisaNetSharedComponentsVersion = typeof(GlobalResourceManager).Assembly.GetName().Version.ToString();
                    Console.WriteLine("VISA implementation compatible with VISA.NET Shared Components {0} not found. Please install corresponding vendor-specific VISA implementation first.", VisaNetSharedComponentsVersion);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // suppress DllNotFoundException exception in Ivi.Visa dispose
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionEventHandler;
        }

        // suppress DllNotFoundException exception in Ivi.Visa dispose
        private static void UnhandledExceptionEventHandler(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            if (ex is DllNotFoundException dllNotFoundException)
            {
                // Dead programs tell no lies
                Process.GetCurrentProcess().Kill();
            }

            throw ex;
        }
    }
}
