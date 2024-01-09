using CrossSpeak;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        CrossSpeakManager.Instance.TrySAPI(true);
        CrossSpeakManager.Instance.Initialize();
        CrossSpeakManager.Instance.Output("Hello!");
        CrossSpeakManager.Instance.Speak("There!", false);
        CrossSpeakManager.Instance.Close();
    }
}