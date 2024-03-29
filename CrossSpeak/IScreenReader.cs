﻿namespace CrossSpeak
{
    public interface IScreenReader
    {
        /// <summary>
        /// Loads and initializes the active screen reader.<br/>
        /// Re-intializes if it has already been loaded.
        /// </summary>
        /// <returns>true if the screen reader was successfully loaded otherwise false.</returns>
        bool Initialize();

        /// <summary>
        /// [Windows and mac only] To check if a screen reader has been loaded or not. <br/>
        /// </summary>
        /// <returns>true if the screen reader has already been loaded otherwise false.</returns>
        bool IsLoaded();

        /// <summary>
        /// Speaks the given text using the active screen reader.
        /// </summary>
        /// <param name="text">The text to be spoken.</param>
        /// <param name="interrupt">Whether or not to cancel speaking the last message or not.</param>
        /// <returns>true if the given text was successfully spoken otherwise false.</returns>
        bool Speak(string text, bool interrupt = true);

        /// <summary>
        /// [Windows and mac only] To check if the screen reader is currently speaking or not.<br/>
        /// Needs more testing on windows!
        /// </summary>
        /// <returns>true if the screen reader is currently speaking otherwise false.</returns>
        bool IsSpeaking();

        /// <summary>
        /// Finalizes and unloads the screen reader drivers.
        /// </summary>
        void Close();

        /// <summary>
        /// [Mac only] Gets the speech volume.
        /// </summary>
        /// <returns>The current speech volume.</returns>
        float GetVolume();

        /// <summary>
        /// [Mac only] Sets the volume level.
        /// </summary>
        /// <param name="volume">The speech volume to be set to.</param>
        void SetVolume(float volume);

        /// <summary>
        /// [Mac only] Gets the speech rate.
        /// </summary>
        /// <returns>The current speech rate.</returns>
        float GetRate();

        /// <summary>
        /// [Mac only] Sets the speech rate.
        /// </summary>
        /// <param name="rate">The speech rate to be set to.</param>
        void SetRate(float rate);

        /// <summary>
        /// [Windows only] To check if the loaded screen reader has speech or not.
        /// </summary>
        /// <returns>true if there is speech otherwise false.</returns>
        bool HasSpeech();

        /// <summary>
        /// [Windows only] Enable or disable auto-detecting SAPI.<br/>
        /// Loading SAPI is disabled by default.
        /// </summary>
        /// <param name="trySAPI">Whether or not to auto-detect SAPI.</param>
        void TrySAPI(bool trySAPI);

        /// <summary>
        /// [Windows only] To set the priority level of SAPI.
        /// </summary>
        /// <param name="preferSAPI">If true than SAPI will become high priority and will be loaded even if any other screen reader is active.</param>
        void PreferSAPI(bool preferSAPI);

        /// <summary>
        /// [Windows only] To check which screen reader is loaded.
        /// </summary>
        /// <returns>The name of the loaded screen reader (JAWS, NVDA, etc).</returns>
        string DetectScreenReader();

        /// <summary>
        /// [Windows only] Attempts to both speak and give a braille output of the given text.
        /// </summary>
        /// <param name="text">The text to be spoken or shown on the braille display.</param>
        /// <param name="interrupt">Whether or not to cancel speaking the last message or not (only for speaking).</param>
        /// <returns>true if the given text was successfully spoken or a braille output was shown.</returns>
        bool Output(string text, bool interrupt = true);

        /// <summary>
        /// [Windows only] To check if the loaded screen reader supports braille.
        /// </summary>
        /// <returns>true if the loaded screen reader supports braille otherwise false.</returns>
        bool HasBraille();

        /// <summary>
        /// [Windows only] Brailles the given text using the loaded screen reader.
        /// </summary>
        /// <param name="text">The text to braille.</param>
        /// <returns>true if successful otherwise false.</returns>
        bool Braille(string text);

        /// <summary>
        /// [Windows only] Silences the screen reader.
        /// </summary>
        /// <returns>true if successful otherwise false.</returns>
        bool Silence();
    }
}
