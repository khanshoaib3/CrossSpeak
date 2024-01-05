using CrossSpeak;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        CrossSpeak.Instance.Initialize();
        CrossSpeak.Instance.Say("Hello There!");
        CrossSpeak.Instance.Close();
    }
}