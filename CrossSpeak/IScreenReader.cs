namespace CrossSpeak
{
    public interface IScreenReader
    {
        public void Initialize();

        public bool IsLoaded();

        public string? DetectScreenReader();

        public bool HasSpeech();

        public bool Speak(string text, bool interrupt = true);

        public bool Output(string text, bool interrupt = true);

        public bool IsSpeaking();

        public float GetVolume();

        public void SetVolume(float volume);

        public float GetRate();

        public void SetRate(float rate);

        public void TrySAPI(bool trySAPI);

        public void PreferSAPI(bool preferSAPI);

        public bool HasBraille();

        public bool Braille(string text);

        public bool Silence();

        public void Close();
    }
}
