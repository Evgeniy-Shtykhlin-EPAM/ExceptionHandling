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
            if (string.IsNullOrWhiteSpace(stringValue) || (stringValue.Contains("+-") || stringValue.Contains("-+") || stringValue.Contains("0-")))
            {
                throw new FormatException();
            }
            if (stringValue == "-2147483648")
            {
                return int.MinValue;
            }

            stringValue = stringValue.Replace(" ", "");
            stringValue = stringValue.Replace("+", "");

            int result = 0;
            int multiple = 1;

            if (stringValue[0] == 45)
            {
                stringValue = stringValue.Replace("-", "");
                for (var i = stringValue.Length - 1; i >= 0; i--)
                {
                    int number;
                    number = (int)((stringValue[i] - '0'));

                    if ((int)stringValue[i] < 48 || (int)stringValue[i] > 57)
                    {
                        throw new FormatException();
                    }
                    else
                    {
                        result = checked(result + (number * multiple));
                        multiple = multiple * 10;
                    }
                }
                result = 0 - result;
            }
            else
            {
                for (var i = stringValue.Length - 1; i >= 0; i--)
                {
                    int number;
                    number = (int)((stringValue[i] - '0'));

                    if ((int)stringValue[i] < 48 || (int)stringValue[i] > 57)
                    {
                        throw new FormatException();
                    }
                    else
                    {
                        result = checked(result + (number * multiple));
                        multiple = multiple * 10;
                    }
                }
            }

            if (result > int.MaxValue || result < int.MinValue)
            {
                throw new OverflowException();             
            }

            return result;
        }
    }    
}