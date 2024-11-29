
public class Checks
{
    public static bool YesNo(string message)
    {
        Console.Write($"{message} y/n");
        while(true)
        {
            ConsoleKey yn = Console.ReadKey().Key;
            if (yn == ConsoleKey.Y)
                return true;
            if (yn == ConsoleKey.N)
                return false;
        }
        
    }
}