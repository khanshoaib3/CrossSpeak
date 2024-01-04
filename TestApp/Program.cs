using DavyKager;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        CrossSpeak.MainClass.Instance.Initialize();
        CrossSpeak.MainClass.Instance.Say("Hello There!");
        CrossSpeak.MainClass.Instance.Close();
    }
}