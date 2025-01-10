namespace TargetSistemas;

public static class Utils
{
    public static void ConsoleTitle(String text)
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}