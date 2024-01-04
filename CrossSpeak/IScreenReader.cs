using System;
using System.Collections.Generic;
using System.Text;

namespace CrossSpeak
{
    public interface IScreenReader
    {
        public void Initialize();

        public bool Say(string text, bool interrupt = true);

        public void Close();
    }
}
