using System.Text;

namespace Calculator
{
    public static class StringExctentions
    {
        public static string SanitizeInput(this string input)
        {
            return input.Replace(" ", "").Replace(",", ".");
        }

        public static string RemoveBrakets(this string input, string openBraket, string closedBraket)
        {
            return input.Replace(openBraket, "").Replace(closedBraket, "");
        }

        public static string Cut(this string input, int startIndex, int endIndex)
        {
            var sb = new StringBuilder(endIndex - startIndex);
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (i >= 0 && i < input.Length)
                {
                    sb.Append(input[i]);
                }
            }

            return sb.ToString();
        }
    }
}
