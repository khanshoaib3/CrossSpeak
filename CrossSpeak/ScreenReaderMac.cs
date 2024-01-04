using System;
using System.Collections.Generic;
using System.Text;

namespace CrossSpeak
{
    internal class ScreenReaderMac : IScreenReader
    {
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public bool Say(string text, bool interrupt)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
