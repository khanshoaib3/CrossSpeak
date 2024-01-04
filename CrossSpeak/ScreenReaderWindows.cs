using DavyKager;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CrossSpeak
{
    internal class ScreenReaderWindows : IScreenReader
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool SetDllDirectory(string lpPathName);

        private bool isLoaded = false;

        public void Initialize()
        {
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string dllDirectory = Path.Combine(assemblyDirectory, "screen-reader-libs", "windows");
            Console.WriteLine(dllDirectory);
            // Call SetDllDirectory to change the DLL search path
            SetDllDirectory(dllDirectory);
            Console.WriteLine("Initializing Tolk...");
            Tolk.TrySAPI(true);
            Tolk.Load();

            Console.WriteLine("Querying for the active screen reader driver...");
            string name = Tolk.DetectScreenReader();
            if (name != null)
            {
                Console.WriteLine($"The active screen reader driver is: {name}");
                isLoaded = true;
            }
            else
            {
                Console.WriteLine("None of the supported screen readers is running");
                isLoaded = false;
            }
        }

        public bool Say(string text, bool interrupt)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;
            if (!isLoaded) return false;

            if (!Tolk.Output(text, interrupt))
            {
                Console.WriteLine($"Failed to output text: {text}");
                return false;
            }
            else
            {
#if DEBUG
                Console.WriteLine($"Speaking(interrupt: {interrupt}) = {text}");
#endif
                return true;
            }
        }

        public void Close()
        {
            if (!isLoaded) return;

            Tolk.Unload();
            isLoaded = false;
        }
    }
}
