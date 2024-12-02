using System.Diagnostics;
using System.Security.Cryptography;

namespace TrenaryTranslator;

class Program
{
    Checks Check = new Checks();
    static void Main(string[] args)
    {
        bool exit = false;
        while(!exit)
        {
            Console.Clear();
            Console.WriteLine("1. Ternary Translator");
            Console.WriteLine("2. Binary Translator");
            Console.WriteLine("0. Exit");
            ConsoleKey choice = Console.ReadKey().Key;
            switch(choice)
            {
                case ConsoleKey.D0:
                    exit = true;
                    Console.Clear();
                    break;
                case ConsoleKey.D1:
                    TernaryMenu();
                    break;
                case ConsoleKey.D2:
                    BinaryMenu();
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
            Console.WriteLine("0. Exit");
            ConsoleKey choice = Console.ReadKey().Key;
            switch (choice)
            {
                case ConsoleKey.D0:
                    return;

                case ConsoleKey.D1:
                    Console.Clear();
                    while(true)
                    {
                        Console.WriteLine();
                        Console.Write("Type in your ASCII text: ");
                        Translators Translate = new Translators();
                        Console.WriteLine(Translate.AsciiToTernary(Console.ReadLine() ?? ""));
                        if (!Checks.YesNo("Do you wish to translate more?"))
                            break;
                    }
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    while(true)
                    {
                        Console.WriteLine();
                        Console.Write("Type in your ternary text: ");
                        Translators Translate = new Translators();
                        Console.WriteLine(Translate.TernaryToAscii(Console.ReadLine() ?? "0"));
                        if (!Checks.YesNo("Do you wish to translate more?"))
                            break;
                    }
                    break;
            }
        }
    }

    static void BinaryMenu()
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine("1. To Binary");
            Console.WriteLine("2. From Binary");
            Console.WriteLine("0. Exit");
            ConsoleKey choice = Console.ReadKey().Key;
            switch (choice)
            {
                case ConsoleKey.D0:
                    return;

                case ConsoleKey.D1:
                    Console.Clear();
                    while(true)
                    {
                        Console.WriteLine();
                        Console.Write("Type in your ASCII text: ");
                        Translators Translate = new Translators();
                        Console.WriteLine(Translate.AsciiToBinary(Console.ReadLine() ?? ""));
                        if (!Checks.YesNo("Do you wish to translate more?"))
                            break;
                    }
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    while(true)
                    {
                        Console.WriteLine();
                        Console.Write("Type in your binary text: ");
                        Translators Translate = new Translators();
                        //Console.WriteLine(Translate.BinaryToAscii(Console.ReadLine() ?? "0"));
                        if (!Checks.YesNo("Do you wish to translate more?"))
                            break;
                    }
                    break;
            }
        }
    }

}
