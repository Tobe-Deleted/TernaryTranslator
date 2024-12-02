using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;
using System.Diagnostics.SymbolStore;

public class Translators
{
    public string TernaryToAscii(string str)
    {
        string result = "";
        string[] strArr = str.Split(' ');
        foreach (string s in strArr)
        {
            string st = s;
            int value = 0;
            int positionalValue = 1;
            if(s.Length < 5)
            {
                for(int i = 0; i < 6 - s.Length; i++)
                {
                    st = st.Insert(0, "0");
                }
            }

            for (int i = 5; i >= 0; i--)
            {
                value += (st[i] -48) * positionalValue;
                positionalValue *= 3;
            }
            if (value > 248 || value < 0)
                throw new ArgumentException($"{s} is outside the ASCII table (0 to 100012)");
            result = result + Convert.ToChar(value);
        }
        return result;
    }

    public string AsciiToTernary(string str)
    {
        string result = "";
        foreach (char ch in str)
        {
            string trenaryBuilder = "000000";
            int iterationValue = 243;
            int charValue = Convert.ToInt32(ch);
            for (int i = 0; i < 6; i++)
            {
                int currentChar = 0;
                for (int j = 0; j < 2; j++)
                {
                    if (charValue >= iterationValue)
                    {
                        charValue -= iterationValue;
                        currentChar += 1;
                    }
                }
                iterationValue /= 3;
                trenaryBuilder = trenaryBuilder.Remove(i, 1).Insert(i, $"{currentChar}");
            }
            result += " " + trenaryBuilder;
        }
        return result;
    }

    public string AsciiToBinary(string str)
    {
        string result = "";
        foreach (char ch in str)
        {
            string binaryBuilder = "00000000";
            int iterationValue = 128;
            int charValue = Convert.ToInt32(ch);
            for (int i = 0; i < 8; i++)
            {
                if (charValue >= iterationValue)
                {
                    charValue -= iterationValue;
                    binaryBuilder = binaryBuilder.Remove(i, 1).Insert(i, "1");
                }
                iterationValue /= 2;
            }
            result += " " + binaryBuilder;
        }

        return result;
    }

    public string BinaryToAscii(string str)
    {
        string result = "";
        string[] strArr = str.Split(' ');
        foreach (string s in strArr)
        {
            int charValue = 0;
            int iterationValue = 128;
            for(int i = 0; i < 8; i++)
            {
                charValue += Convert.ToInt32(s[i] -48) * iterationValue; 
                iterationValue /= 2;
            }
            result += Convert.ToChar(charValue);
        }
        return result;
    }

    public void CaesarCipher(string str, int n)
    {
        bool norwegian = true;
        Dictionary<int, char> IntToChar = new Dictionary<int, char>()
        {
            {1, 'a'},
            {2, 'b'},
            {3, 'c'},
            {4, 'd'},
            {5, 'e'},
            {6, 'f'},
            {7, 'g'},
            {8, 'h'},
            {9, 'i'},
            {10, 'j'},
            {11, 'k'},
            {12, 'l'},
            {13, 'm'},
            {14, 'n'},
            {15, 'o'},
            {16, 'p'},
            {17, 'q'},
            {18, 'r'},
            {19, 's'},
            {20, 't'},
            {21, 'u'},
            {22, 'v'},
            {23, 'w'},
            {24, 'x'},
            {25, 'y'},
            {26, 'z'},
            {27, 'æ'},
            {28, 'ø'},
            {29, 'å'}
        };
        Dictionary<char, int> CharToInt = new Dictionary<char, int>()
        {
            {'a', 1},
            {'b', 2},
            {'c', 3},
            {'d', 4},
            {'e', 5},
            {'f', 6},
            {'g', 7},
            {'h', 8},
            {'i', 9},
            {'j', 10},
            {'k', 11},
            {'l', 12},
            {'m', 13},
            {'n', 14},
            {'o', 15},
            {'p', 16},
            {'q', 17},
            {'r', 18},
            {'s', 19},
            {'t', 20},
            {'u', 21},
            {'v', 22},
            {'w', 23},
            {'x', 24},
            {'y', 25},
            {'z', 26},
            {'æ', 27},
            {'ø', 28},
            {'å', 29}
        };
        while (true)
        {
            int maxShift = 28;
            if(!norwegian) maxShift = 25;
            string result = "";
            Console.Clear();
            if (n < 0) n = maxShift;
            if (n > maxShift) n = 0;
            foreach(char ch in str)
            {
                if(Char.IsLetter(ch))
                {
                    int chValue = CharToInt[ch];
                    chValue += n;
                    if (chValue > maxShift +1)
                        chValue += - maxShift +1;
                    result += IntToChar[chValue];
                }
                else
                    result += ch;
            }
            if(n == 29) Console.WriteLine("Shift: 0");
            else Console.WriteLine($"Shift: {n}");
            if (norwegian)Console.WriteLine($"Using the Norwegian alphabet");
            else Console.WriteLine($"Using the English alphabet");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{result}");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("| - shift: (arrow left) <--   |   + shift: (arrow right) --> |");
            Console.WriteLine("change alphabet: (arrow up) ^ | exit: (zero) 0");
            ConsoleKey CipherShift = Console.ReadKey().Key;
            switch (CipherShift)
            {
                case ConsoleKey.LeftArrow:
                    n -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    n += 1;
                    break;
                case ConsoleKey.UpArrow:
                    Console.Clear();
                    Console.ReadKey();
                    if (norwegian)norwegian = false;
                    else norwegian = true;
                    break;
                case ConsoleKey.D0:
                    return;
                
            }
        }
    }
}