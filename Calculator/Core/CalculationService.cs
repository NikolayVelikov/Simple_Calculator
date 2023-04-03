using Calculator.Interfaces;
using System.Text;

namespace Calculator.Core
{
    public class CalculationService : ICalculationService
    {
        public string EvaluateExpression(string input)
        {
            var _continue = true;
            while (_continue)
            {
                var extracted = Extract(input);
                if (extracted == input)
                {
                    _continue = false;
                }

                var result = Result(extracted);

                input = input.Replace(extracted, result);
            }

            return input;
        }

        private string Result(string input)
        {
            input = input.RemoveBrakets("(", ")");

            var countOfMultyOrDivideSign = 0;
            var tokens = PrepareForCalculation(input, ref countOfMultyOrDivideSign);

            if (countOfMultyOrDivideSign > 0)
            {
                CalculateDivideAndMulty(tokens, countOfMultyOrDivideSign);
            }

            var result = CalculateAdditionAndSubtraction(tokens);

            return result.ToString();
        }

        private List<string> PrepareForCalculation(string input, ref int countOfMultyOrDivideSign)
        {
            var tokens = new List<string>();
            var sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                var item = input[i].ToString();
                if (Validator.IsDigit(item) || Validator.IsDot(item) || sb.Length == 0 && tokens.Count == 0)
                {
                    sb.Append(item);
                    continue;
                }
                else if (Validator.IsSubtractionSymbol(item))
                {
                    var previous = tokens.Count > 0 ? tokens.Last() : null;
                    if (!Validator.IsNumber(previous) && previous is not null)
                    {
                        if (Validator.IsNumber(sb.ToString()))
                        {
                            tokens.Add(sb.ToString());
                            sb = new StringBuilder();
                            tokens.Add(item);
                            continue;
                        }
                        sb.Append(item);
                        continue;
                    }
                }

                tokens.Add(sb.ToString());
                sb = new StringBuilder();
                tokens.Add(item.ToString());

                if (Validator.IsMultySymbol(item) || Validator.IsDivideSymbol(item))
                {
                    countOfMultyOrDivideSign++;
                }
            }

            tokens.Add(sb.ToString());

            return tokens;
        }

        private void CalculateDivideAndMulty(List<string> tokens, int countOfMultyOrDivideSign)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                var symbol = tokens[i];

                if (Validator.IsMultySymbol(symbol) || Validator.IsDivideSymbol(symbol))
                {
                    DivideOrMultiply(symbol, i, tokens);
                    i = -1;
                    countOfMultyOrDivideSign--;
                }
            }
        }

        private string CalculateAdditionAndSubtraction(List<string> tokens)
        {
            var result = double.Parse(tokens[0]);
            for (int i = 1; i < tokens.Count; i += 2)
            {
                var op = tokens[i];
                var num = double.Parse(tokens[i + 1]);

                if (Validator.IsPlusSymbol(op))
                {
                    result += num;
                }
                else if (Validator.IsSubtractionSymbol(op))
                {
                    result -= num;
                }
            }

            return result.ToString();
        }

        private void DivideOrMultiply(string symbol, int index, List<string> tokens)
        {
            var left = double.Parse(tokens[index - 1]);
            var right = double.Parse(tokens[index + 1]);
            var result = 0.0;

            if (Validator.IsMultySymbol(symbol))
            {
                result = left * right;
            }
            else if (Validator.IsDivideSymbol(symbol))
            {
                result = left / right;
            }

            tokens[index - 1] = result.ToString();
            tokens.RemoveAt(index);
            tokens.RemoveAt(index);
        }

        private string Extract(string input)
        {
            var startIndex = 0;
            var endIndex = input.Length - 1;

            for (int i = 0; i < input.Length; i++)
            {
                var item = input[i].ToString();

                if (Validator.PossibleSymbolForEvaluation(item))
                {
                    continue;
                }

                if (Validator.IsOpenRoundBracket(item))
                {
                    startIndex = i;
                }
                else if (Validator.IsCloseRoundBracket(item))
                {
                    endIndex = i;
                    break;
                }
            }

            var extracted = input.Cut(startIndex, endIndex);
            return extracted;
        }
    }
}