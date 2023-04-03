namespace Calculator
{
    public static class Validator
    {
        public static bool PossibleSymbolForEvaluation(string value)
        {
            if (IsDot(value) || IsDigit(value) || IsPlusSymbol(value) || IsSubtractionSymbol(value) || IsMultySymbol(value) || IsDivideSymbol(value))
            {
                return true;
            }

            return false;
        }

        public static bool IsMultySymbol(string value)
        {
            if (value == "*")
            {
                return true;
            }

            return false;
        }

        public static bool IsDivideSymbol(string value)
        {
            if (value == "/")
            {
                return true;
            }

            return false;
        }

        public static bool IsPlusSymbol(string value)
        {
            if (value == "+")
            {
                return true;
            }

            return false;
        }

        public static bool IsSubtractionSymbol(string value)
        {
            if (value == "-")
            {
                return true;
            }

            return false;
        }

        public static bool IsDot(string value)
        {
            if (value == ".")
            {
                return true;
            }

            return false;
        }

        public static bool IsDigit(string value)
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Length == 1 && char.IsDigit(char.Parse(value)))
            {
                return true;
            }

            return false;
        }

        public static bool IsNumber(string value)
        {
            if (double.TryParse(value, out double result))
            {
                return true;
            }

            return false;
        }

        public static bool IsOpenRoundBracket(string value)
        {
            if (value == "(")
            {
                return true;
            }

            return false;
        }

        public static bool IsCloseRoundBracket(string value)
        {
            if (value == ")")
            {
                return true;
            }

            return false;
        }

        public static bool IsValidInputWitnRoundBrakets(string input)
        {
            var stack = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                var item = input[i].ToString();

                if (IsOpenRoundBracket(item))
                {
                    stack.Push(item);
                }
                else if (IsCloseRoundBracket(item))
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    stack.Pop();
                }
                else if (!IsOpenRoundBracket(item) && !IsCloseRoundBracket(item) && !PossibleSymbolForEvaluation(item))
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}