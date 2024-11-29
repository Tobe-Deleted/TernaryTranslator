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
}