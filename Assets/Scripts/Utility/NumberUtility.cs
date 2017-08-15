using System.Collections.Generic;

public static class NumberUtility
{
    private static Dictionary<int, string> _normalizedNumbers;
    private static Dictionary<int, string> normalizedNumbers
    {
        get
        {
            if (_normalizedNumbers == null)
            {
                _normalizedNumbers = new Dictionary<int, string>(10);
                for (int i = 0; i < 10; i++)
                    _normalizedNumbers[i] = NormalizedNumberInternal(i);
            }
            return _normalizedNumbers;
        }
    }

    public static string NormalizedNumber(int number)
    {
        if (number < 10) return normalizedNumbers[number];
        return number.ToString();
    }

    private static string NormalizedNumberInternal(int number)
    {
        if (number < 10)
            return "0" + number;
        return number.ToString();
    }
}
