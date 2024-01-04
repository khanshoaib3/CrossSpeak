using System;
using System.Collections.Generic;
using System.Text;

namespace CrossSpeak
{
    internal class ScreenReaderMac : IScreenReader
    {
        void IScreenReader.Close()
        {
            throw new NotImplementedException();
        }

        void IScreenReader.Initialize()
        {
            throw new NotImplementedException();
        }

        bool IScreenReader.Say(string text, bool interrupt)
        {
            throw new NotImplementedException();
        }
    }
}
