using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException();
            }
            if (stringValue == "-2147483648")
            {
                return int.MinValue;
            }

            bool opposite = false;

            IsAllSymbolNumbers(ref stringValue, ref opposite);

            int result = 0;
            int multiple = 1;
            for (var i = stringValue.Length - 1; i >= 0; i--)
            {
                int number;
                number = stringValue[i] - '0';

                result = checked(result + (number * multiple));

                multiple *= 10;
            }

            if (opposite)
            {
                result = 0 - result;
            }

            return result;
        }
        public static void IsAllSymbolNumbers(ref string stringValue,ref bool opposite)
        {
            if (string.IsNullOrWhiteSpace(stringValue) || (stringValue.Contains("+-") || stringValue.Contains("-+") || stringValue.Contains("0-")))
            {
                throw new FormatException();
            }

            stringValue = stringValue.Replace(" ", "");
            stringValue = stringValue.Replace("+", "");

            if (stringValue[0] == 45)
            {
                opposite = true;
            }

            stringValue = stringValue.Replace("-", "");
            for (int i = 0; i < stringValue.Length-1; i++)
            {
                if (stringValue[i] < 48 || stringValue[i] > 57)
                {
                    throw new FormatException();
                }
            }
        }
    }    
}