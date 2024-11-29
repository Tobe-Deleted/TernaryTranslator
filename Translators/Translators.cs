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
                for(int i = 0; i < 5 - s.Length; i++)
                {
                    st = st.Insert(0, "0");
                }
            }

            for (int i = 4; i >= 0; i--)
            {
                value += (st[i] -48) * positionalValue;
                positionalValue *= 3;
            }
            if (value > 127 || value < 0)
                throw new ArgumentException($"{s} is outside of ASCII table (0 to 11201)");
            result = result + Convert.ToChar(value);
        }
        return result;
    }
}