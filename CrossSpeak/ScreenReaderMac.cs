using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace CrossSpeak
{
    internal class ScreenReaderMac : IScreenReader
    {
        protected class LibSpeakAPI
        {
            #region Speaker
            
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void init_speaker();
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
#pragma warning restore CA2101 // Specify marshaling for P/Invoke string arguments
            internal static extern void speak(String text);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void set_voice(Int32 index);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern UInt32 available_voices_count();
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void set_language(Int32 index);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern UInt32 available_languages_count();
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
#pragma warning restore CA2101 // Specify marshaling for P/Invoke string arguments
            internal static extern void get_voice_name(UInt32 idx, String pszOut);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void set_volume(Single volume);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern Single get_volume();
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void set_rate(Single rate);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern Single get_rate();
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void stop();
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void cleanup_speaker();
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void mainloop_speaker(IntPtr speaker);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern Boolean is_speaking(IntPtr speaker);

            #endregion

            #region Speaker OO

            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern IntPtr make_speaker();
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void speak_with(IntPtr speaker, [MarshalAs(UnmanagedType.LPUTF8Str)] String text);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void set_voice_with(IntPtr speaker, Int32 index);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void set_volume_with(IntPtr speaker, Single volume);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern Single get_volume_with(IntPtr speaker);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void set_rate_with(IntPtr speaker, Single rate);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern Single get_rate_with(IntPtr speaker);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void stop_with(IntPtr speaker);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void cleanup_with(IntPtr speaker);

            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void register_will_speak_word_callback(IntPtr speaker, [MarshalAs(UnmanagedType.FunctionPtr)] wsw_callback cb);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void register_will_speak_phoneme_callback(IntPtr speaker, [MarshalAs(UnmanagedType.FunctionPtr)] wsp_callback cb);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void register_did_finish_speaking_callback(IntPtr speaker, [MarshalAs(UnmanagedType.FunctionPtr)] dfs_callback cb);

            #endregion

            #region Recognizer OO

            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern IntPtr make_listener();
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void start_listening(IntPtr listener);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void stop_listening(IntPtr listener);
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
#pragma warning restore CA2101 // Specify marshaling for P/Invoke string arguments
            internal static extern void add_command(IntPtr listener, String command);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void cleanup_listener(IntPtr listener);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void mainloop_listener(IntPtr listener);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern Boolean is_listening(IntPtr listener);
            [DllImport("lib/screen-reader-libs/macos/libspeak.dylib", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void register_did_recognize_command_callback(IntPtr listener, drc_callback cb);

            #endregion
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void wsw_callback(String p1);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void wsp_callback(Int16 p1);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void dfs_callback();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void drc_callback(String p1);

        // The speaker instance
        private static IntPtr speaker;
        //Stuff for the runloop thread
        private readonly CancellationTokenSource cts = new CancellationTokenSource();
        private Thread? rt;
        //Speech queue for interrupt
        private static readonly Queue<string> speechQueue = new Queue<string>();

        // DidFinishSpeaking callback for interrupt
        readonly dfs_callback fscb = new dfs_callback(DoneSpeaking);

        private static void SpeakLoop(object? obj)
        {
            if (obj == null) return;

            CancellationToken ct = (CancellationToken)obj;

            while (!ct.IsCancellationRequested)
            {
                LibSpeakAPI.mainloop_speaker(speaker);
                Thread.Sleep(20);
            }
        }

        private static void DoneSpeaking()
        {
            if (speechQueue.Count == 0) return;
            LibSpeakAPI.speak_with(speaker, speechQueue.Dequeue());
        }

        public void Initialize()
        {
            if (IsLoaded()) Close();

            speaker = LibSpeakAPI.make_speaker();
            rt = new Thread(new ParameterizedThreadStart(SpeakLoop));
            rt.Start(cts.Token);
            LibSpeakAPI.register_did_finish_speaking_callback(speaker, fscb);
        }

        public bool IsLoaded() => speaker != IntPtr.Zero;

        public string? DetectScreenReader() => null;

        public bool HasSpeech() => IsLoaded();

        public bool Speak(string text, bool interrupt = true)
        {
            if (text == null) return false;
            if (string.IsNullOrWhiteSpace(text)) return false;

            if (interrupt)
            {
                speechQueue.Clear();
                LibSpeakAPI.speak_with(speaker, text);
            }
            else
            {
                speechQueue.Enqueue(text);
            }

            return true;
        }

        public bool Output(string text, bool interrupt) => Speak(text, interrupt) || Braille(text);

        public bool IsSpeaking() => LibSpeakAPI.is_speaking(speaker) && speechQueue.Count != 0;

        public float GetVolume() => IsLoaded() ? LibSpeakAPI.get_volume_with(speaker) : 0.0f;

        public void SetVolume(float volume) { if (IsLoaded()) LibSpeakAPI.set_volume_with(speaker, volume); }

        public float GetRate() => IsLoaded() ? LibSpeakAPI.get_rate_with(speaker) : 0.0f;

        public void SetRate(float rate) { if (IsLoaded()) LibSpeakAPI.set_rate_with(speaker, rate); }

        public void TrySAPI(bool trySAPI) { }

        public void PreferSAPI(bool preferSAPI) { }

        public bool HasBraille() => false;

        public bool Braille(string text) => false;

        public bool Silence() => false;

        public void Close()
        {
            cts.Cancel();
            rt?.Join();
            cts.Dispose();
            LibSpeakAPI.cleanup_with(speaker);
        }
    }
}
