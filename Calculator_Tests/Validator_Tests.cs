using Calculator;
using FluentAssertions;

namespace Calculator_Tests
{
    public class Validator_Tests
    {
        [Theory]
        [InlineData("*", true)]
        [InlineData("[", false)]
        [InlineData("(", false)]
        [InlineData(")", false)]
        [InlineData("-", false)]
        [InlineData("/", false)]
        [InlineData(null, false)]
        public void Should_ValidateIsMultySymbol(string symbol, bool expected)
        {
            var result = Validator.IsMultySymbol(symbol);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("/", true)]
        [InlineData("[", false)]
        [InlineData("(", false)]
        [InlineData(")", false)]
        [InlineData("-", false)]
        [InlineData("*", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void Should_ValidateIsDivideSymbol(string symbol, bool expected)
        {
            var result = Validator.IsDivideSymbol(symbol);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("+", true)]
        [InlineData("[", false)]
        [InlineData("(", false)]
        [InlineData(")", false)]
        [InlineData("-", false)]
        [InlineData("*", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void Should_ValidateIsPlusSymbol(string symbol, bool expected)
        {
            var result = Validator.IsPlusSymbol(symbol);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("-", true)]
        [InlineData("[", false)]
        [InlineData("(", false)]
        [InlineData(")", false)]
        [InlineData("/", false)]
        [InlineData("*", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void Should_ValidateIsSubtractionSymbol(string symbol, bool expected)
        {
            var result = Validator.IsSubtractionSymbol(symbol);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(".", true)]
        [InlineData("[", false)]
        [InlineData("(", false)]
        [InlineData(")", false)]
        [InlineData("-", false)]
        [InlineData("*", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void Should_ValidateIsDotSymbol(string symbol, bool expected)
        {
            var result = Validator.IsDot(symbol);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("(", true)]
        [InlineData(")", false)]
        [InlineData("[", false)]
        [InlineData("]", false)]
        [InlineData("{", false)]
        [InlineData("}", false)]
        [InlineData("<", false)]
        [InlineData(">", false)]
        public void Should_ValidateIsOpenRoundBracket(string symbol, bool expected)
        {
            var result = Validator.IsOpenRoundBracket(symbol);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(")", true)]
        [InlineData("(", false)]
        [InlineData("[", false)]
        [InlineData("]", false)]
        [InlineData("{", false)]
        [InlineData("}", false)]
        [InlineData("<", false)]
        [InlineData(">", false)]
        public void Should_ValidateIsCloseRoundBracket(string symbol, bool expected)
        {
            var result = Validator.IsCloseRoundBracket(symbol);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("1", true)]
        [InlineData("5", true)]
        [InlineData("55", false)]
        [InlineData("A", false)]
        [InlineData("(", false)]
        [InlineData(null, false)]
        public void Should_ValidateIsDigit(string symbol, bool expected)
        {
            var result = Validator.IsDigit(symbol);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("(1+1)", true)]
        [InlineData("(1+1)+(2*(1+5))", true)]
        [InlineData("(1+1)+(2*(1+5)", false)]
        [InlineData(")1+5", false)]
        [InlineData("1+1*(2*5))", false)]
        [InlineData("-1+10*(5*)1+5))", false)]
        [InlineData("(1+1", false)]
        public void Should_ValidateIsValidInputWitnRoundBrakets(string symbol, bool expected)
        {
            var result = Validator.IsValidInputWitnRoundBrakets(symbol);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("*", true)]
        [InlineData("/", true)]
        [InlineData("+", true)]
        [InlineData("-", true)]
        [InlineData("(", false)]
        [InlineData(")", false)]
        [InlineData("[", false)]
        [InlineData("]", false)]
        [InlineData("{", false)]
        [InlineData("}", false)]
        [InlineData("<", false)]
        [InlineData(">", false)]
        public void Should_Validate_If_The_Symbol_Is_Possible_At_The_Context_Of_The_App(string symbol, bool expected)
        {
            var result = Validator.PossibleSymbolForEvaluation(symbol);

            result.Should().Be(expected);
        }
    }
}