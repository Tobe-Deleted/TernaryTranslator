namespace TrenaryTranslator;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1. Ternary Translations");
        Console.Write("type in your ternary text: ");
        Translators Translate = new Translators();
        Console.WriteLine(Translate.TernaryToAscii(Console.ReadLine() ?? "0"));
    }
}
