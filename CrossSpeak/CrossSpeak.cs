using System;
using System.Runtime.InteropServices;

namespace CrossSpeak
{
    public class CrossSpeak
    {
        private static IScreenReader? _instance;

        public static IScreenReader Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        _instance = new ScreenReaderWindows();
                    }
                    else if (RuntimeInformation.IsOSPlatform (OSPlatform.Linux))
                    {
                        _instance = new ScreenReaderLinux();
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        _instance = new ScreenReaderMac();
                    }
                    else
                    {
                        throw new Exception("Platform not supported!!");
                    }

                    _instance.Initialize();
                }

                return _instance;
            }
        }
    }
}
