using CrossSpeak;
using DavyKager;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        
        CrossSpeak.CrossSpeak.Instance.TrySAPI(true);
        CrossSpeak.CrossSpeak.Instance.Initialize();
        CrossSpeak.CrossSpeak.Instance.Speak("Hello!");
        Console.WriteLine(CrossSpeak.CrossSpeak.Instance.IsSpeaking());
        Console.WriteLine(CrossSpeak.CrossSpeak.Instance.HasSpeech());
        Console.WriteLine(CrossSpeak.CrossSpeak.Instance.HasSpeech());
        Console.WriteLine(CrossSpeak.CrossSpeak.Instance.IsLoaded());
        CrossSpeak.CrossSpeak.Instance.Speak("There!", false);
        Console.WriteLine(CrossSpeak.CrossSpeak.Instance.Silence());
        CrossSpeak.CrossSpeak.Instance.Speak("Helllo There!", false);
        CrossSpeak.CrossSpeak.Instance.Close();

    }
}