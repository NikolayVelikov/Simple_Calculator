using Calculator;
using Calculator.Interfaces;
using FluentAssertions;

namespace Calculator_Tests
{
    public class StringExctentions_Tests
    {

        [Theory]
        [InlineData("1 +1 * (1/5 )", "1+1*(1/5)")]
        [InlineData("1,1+5.9", "1.1+5.9")]
        [InlineData("1, 1+5.9", "1.1+5.9")]
        [InlineData("1 + 1 *(5,5/5.5)", "1+1*(5.5/5.5)")]
        public void Should_Remove_EmptySpace_And_Replace_Comma_With_Dot(string input, string expected)
        {
            var result = input.SanitizeInput();

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("()", "")]
        [InlineData("1+1*(1/5)", "1+1*1/5")]
        [InlineData("(1, 1+5.9)", "1, 1+5.9")]
        public void Should_Remove_Brakets(string input, string expected)
        {
            string openBraket = "(";
            string closeBraket = ")";

            var result = input.RemoveBrakets(openBraket, closeBraket);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("01234", 0, 3, "0123")]
        [InlineData("abc789zkv", 2, 6, "c789z")]
        [InlineData("test", 10, 15, "")]
        public void Should_Cout_Out(string input, int startIndex, int endIndex, string expected)
        {
            string result = input.Cut(startIndex, endIndex);

            result.Should().Be(expected);
        }
    }
}