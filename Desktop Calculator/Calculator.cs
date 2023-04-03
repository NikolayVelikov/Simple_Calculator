using Calculator;
using Calculator.Interfaces;

namespace Desktop_Calculator
{
    public partial class Calculator : Form
    {
        private readonly IEngine _calculator;

        public Calculator(IEngine calculator)
        {
            InitializeComponent();

            _calculator = calculator;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            var input = textBox1.Text;

            var result = _calculator.Run(input);

            textBox2.Text = result;
        }

        private void reset_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }
    }
}
