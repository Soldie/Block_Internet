namespace IEque
{
    using Microsoft.Win32;
    using System;
    using System.IO;
    using System.Security;

    public class BlockIE
    {
        private enum INTERNET_OPTION : int
        {
            INTERNET_OPEN_TYPE_PROXY = 3,
            INTERNET_OPTION_REFRESH = 37,
            INTERNET_OPTION_PROXY = 38,
            INTERNET_OPTION_SETTINGS_CHANGED = 39,
            INTERNET_OPTION_VERSION = 40,
            INTERNET_OPTION_PER_CONNECTION_OPTION = 75
        }

        public static void Enabled(int block_internet)
        {
            string ProxyIP = "2.23.143.150:443", ProxyEnable = "ProxyEnable", ProxyServer = "ProxyServer";

            const string IE = @"Software\Microsoft\Windows\CurrentVersion\Internet Settings";
            using (var hklmHive_x64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32))
            {
                using (RegistryKey runKey = hklmHive_x64.OpenSubKey(IE, Environment.Is64BitOperatingSystem ? true : false))
                {
                    try
                    {
                        switch (block_internet)
                        {
                            case 0:
                                runKey?.DeleteValue(ProxyEnable);
                                runKey?.DeleteValue(ProxyServer);
                                Console.WriteLine("Proxy Delete!");
                                break;
                            case 1:
                                runKey?.SetValue(ProxyEnable, block_internet);
                                runKey?.SetValue(ProxyServer, ProxyIP);
                                Console.WriteLine("Proxy Installed");
                                break;
                            default:
                                break;
                        }
                        NativeMethods.InternetSetOption(IntPtr.Zero, (int)INTERNET_OPTION.INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
                        NativeMethods.InternetSetOption(IntPtr.Zero, (int)INTERNET_OPTION.INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
                    }
                    catch (UnauthorizedAccessException) { }
                    catch (ArgumentException) { }
                    catch (IOException) { }
                    catch (SecurityException) { }
                }
            }
        }
    }
}