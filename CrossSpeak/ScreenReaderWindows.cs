using DavyKager;
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

        public ScreenReaderWindows()
        {
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            if (assemblyDirectory == string.Empty) return;
            string dllDirectory = Path.Combine(assemblyDirectory, "lib", "screen-reader-libs", "windows");
            SetDllDirectory(dllDirectory);
        }

        public void Initialize()
        {
            if (isLoaded) Close();

            Tolk.Load();

            string name = Tolk.DetectScreenReader();
            isLoaded = name != null;
        }

        public bool IsLoaded() => isLoaded && Tolk.IsLoaded();

        public void TrySAPI(bool trySAPI) => Tolk.TrySAPI(trySAPI);

        public void PreferSAPI(bool preferSAPI) => Tolk.PreferSAPI(preferSAPI);

        public string? DetectScreenReader() => isLoaded ? Tolk.DetectScreenReader() : null;

        public bool HasSpeech() => isLoaded && Tolk.HasSpeech();

        public bool HasBraille() => isLoaded && Tolk.HasBraille();

        public bool Speak(string text, bool interrupt = false)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;
            if (!isLoaded) return false;

            return Tolk.Speak(text, interrupt);
        }

        public bool Braille(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;
            if (!isLoaded) return false;

            return Tolk.Braille(text);
        }

        public bool Output(string text, bool interrupt = false)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;
            if (!isLoaded) return false;

            return Tolk.Output(text, interrupt);
        }

        public bool IsSpeaking() => isLoaded && Tolk.IsSpeaking();

        public float GetVolume() => 0.0f;

        public void SetVolume(float volume) { }

        public float GetRate() => 0.0f;

        public void SetRate(float rate) { }

        public bool Silence() => isLoaded && Tolk.Silence();

        public void Close()
        {
            if (!isLoaded) return;

            Tolk.Unload();
            isLoaded = false;
        }
    }
}
