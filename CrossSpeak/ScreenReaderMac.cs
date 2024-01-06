using System;

namespace CrossSpeak
{
    internal class ScreenReaderMac : IScreenReader
    {
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public bool IsLoaded()
        {
            throw new NotImplementedException();
        }

        public string? DetectScreenReader()
        {
            throw new NotImplementedException();
        }

        public bool HasSpeech()
        {
            throw new NotImplementedException();
        }

        public bool Speak(string text, bool interrupt = true)
        {
            throw new NotImplementedException();
        }

        public bool Output(string text, bool interrupt)
        {
            throw new NotImplementedException();
        }

        public bool IsSpeaking()
        {
            throw new NotImplementedException();
        }

        public void TrySAPI(bool trySAPI)
        {
            throw new NotImplementedException();
        }

        public void PreferSAPI(bool preferSAPI)
        {
            throw new NotImplementedException();
        }

        public bool HasBraille()
        {
            throw new NotImplementedException();
        }

        public bool Braille(string text)
        {
            throw new NotImplementedException();
        }

        public bool Silence()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
