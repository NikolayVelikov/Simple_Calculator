using Calculator.Core;
using Calculator.Interfaces;
using FluentAssertions;

namespace Calculator_Tests
{
    public class CalculatorEngine_Tests
    {
        private readonly IEngine _engine;

        public CalculatorEngine_Tests()
        {
            _engine = new CalculatorEngine();
        }

        [Theory]
        [InlineData("1,2 / ( 5- 10)* (1-2 )", "0.24")]
        [InlineData("-1+5 *3-4", "10")]
        [InlineData("(1+5/( 3+2)+((1*15)+15 ))", "32")]
        public void Should_Return_Number_AS_Result(string input, string expected)
        {
            var result = _engine.Run(input);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("1+ 5)", "Error with the input")]
        [InlineData("1+ [1+5]", "Error with the input")]
        [InlineData("1+ {1+5}", "Error with the input")]
        [InlineData("1+ 2 +<1-5>", "Error with the input")]
        [InlineData("(1 + 5 / <3 + 2) + ((1 * 15) + 15))", "Error with the input")]
        public void Should_Return_Error_Message_When_The_Input_Is_Incorect(string input, string expected)
        {
            var result = _engine.Run(input);

            result.Should().Be(expected);
        }
    }
}