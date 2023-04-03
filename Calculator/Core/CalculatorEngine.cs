using Calculator.Interfaces;

namespace Calculator.Core
{
    public class CalculatorEngine : IEngine
    {
        private readonly ICalculationService _calculationService;

        public CalculatorEngine()
        {
            _calculationService = new CalculationService();
        }

        public string Run(string input)
        {
            input = input.SanitizeInput();
            var isValid = Validator.IsValidInputWitnRoundBrakets(input);

            if (isValid)
            {
                var result = _calculationService.EvaluateExpression(input);
                return result;
            }

            return "Error with the input";
        }
    }
}