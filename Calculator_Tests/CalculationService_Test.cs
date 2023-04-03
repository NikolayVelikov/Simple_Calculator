using Calculator.Core;
using Calculator.Interfaces;
using FluentAssertions;

namespace Calculator_Tests
{
    public class CalculationService_Test
    {
        private readonly ICalculationService _calculation;

        public CalculationService_Test()
        {
            _calculation = new CalculationService();
        }

        [Theory]
        [InlineData("(1+2)*4/6", "2")]
        [InlineData("3*(4+5)", "27")]
        [InlineData("2+3+(4+5)*6", "59")]
        [InlineData("-1+5*3-4", "10")]
        [InlineData("(1+5/(3+2)+((1*15)+15))", "32")]
        [InlineData("(1+(-3*4))", "-11")]
        [InlineData("(1+(-3*4*-1))", "13")]
        [InlineData("1-(-1)", "2")]
        [InlineData("1/(5-10)*(1-2)", "0.2")]
        public void Should_Return_Number_Result(string input, string expected)
        {
            var result = _calculation.EvaluateExpression(input);

            result.Should().Be(expected);
        }
    }
}