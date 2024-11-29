using System.Diagnostics;
using System.Security.Cryptography;

namespace TrenaryTranslator;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;
        while(!exit)
        {
            Console.Clear();
            Console.WriteLine("1. Ternary Translations");
            Console.WriteLine("0. Exit");
            ConsoleKey choice = Console.ReadKey().Key;
            switch(choice)
            {
                case ConsoleKey.D1:
                TernaryMenu();
                break;
                case ConsoleKey.D0:
                    exit = true;
                    break;
            }
        }
    }
    static void TernaryMenu()
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine("1. To Ternary");
            Console.WriteLine("2. From Ternary");
            ConsoleKey choice = Console.ReadKey().Key;
            switch (choice)
            {
                case ConsoleKey.D0:
                    return;
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.D2:
                    Console.Write("Type in your ternary text: ");
                    Translators Translate = new Translators();
                    Console.WriteLine(Translate.TernaryToAscii(Console.ReadLine() ?? "0"));
                    
                    break;
            }
        }
    }
    
}
