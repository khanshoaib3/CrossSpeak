﻿using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CrossSpeak
{
    internal class LibSpeechdWrapperAPI
    {
        internal readonly struct GoString
        {
            public string Msg { get; }
            public long Len { get; }

            public GoString(string msg, long len)
            {
                Msg = msg;
                Len = len;
            }
        }

        [DllImport("libspeechdwrapper")]
        internal static extern int Initialize();

        [DllImport("libspeechdwrapper")]
        internal static extern int Speak(GoString text, bool interrupt);

        [DllImport("libspeechdwrapper")]
        internal static extern int Close();
    }

    internal class ScreenReaderLinux : IScreenReader
    {

        private bool initialized = false, resolvedDll = false;
        private IntPtr libraryHandle;

        public void Initialize()
        {
            Console.WriteLine("Initializing speech dispatcher...");
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string dllDirectory = Path.Combine(assemblyDirectory, "screen-reader-libs", "linux", "libspeechdwrapper.so");
            libraryHandle = dlopen(dllDirectory, RTLD_NOW);
            if (libraryHandle == IntPtr.Zero)
            {
                throw new Exception($"Failed to load the shared library: {dllDirectory}");
            }

            int res = LibSpeechdWrapperAPI.Initialize();
            if (res == 1)
            {
                initialized = true;
                Console.WriteLine("Successfully initialized.");
            }
            else
            {
                Console.WriteLine("Unable to initialize.");
            }
        }

        public bool Say(string text, bool interrupt)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;
            if (!initialized && libraryHandle == IntPtr.Zero) return false;

            LibSpeechdWrapperAPI.GoString str = new LibSpeechdWrapperAPI.GoString(text, text.Length);
            int re = LibSpeechdWrapperAPI.Speak(str, interrupt);

            if (re != 1)
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
            if (initialized && libraryHandle != IntPtr.Zero)
            {
                LibSpeechdWrapperAPI.Close();
                initialized = false;
                libraryHandle = IntPtr.Zero;
            }
        }


        // Declare dlopen and dlclose functions from dl library
        private const int RTLD_NOW = 2; // for dlopen's flags

        [DllImport("libdl")]
        private static extern IntPtr dlopen(string path, int flags);

        [DllImport("libdl")]
        private static extern int dlclose(IntPtr handle);
    }
}