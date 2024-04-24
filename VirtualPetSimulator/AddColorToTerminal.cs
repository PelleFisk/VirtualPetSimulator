namespace VirtualPetSimulator;

public class AddColorToTerminal
{
    public static void AddColor(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"{text}");
        Console.ResetColor();
    }
}