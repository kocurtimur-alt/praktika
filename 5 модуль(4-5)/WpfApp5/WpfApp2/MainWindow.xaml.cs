using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private double _result;
        private string _operation;
        private bool _isOperationPerformed;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (_isOperationPerformed)
            {
                ResultTextBox.Text = button.Content.ToString();
                _isOperationPerformed = false;
            }
            else
            {
                ResultTextBox.Text += button.Content.ToString();
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (double.TryParse(ResultTextBox.Text, out _result))
            {
                _operation = button.Content.ToString();
                _isOperationPerformed = true;
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            double secondOperand;

            if (double.TryParse(ResultTextBox.Text, out secondOperand))
            {
                switch (_operation)
                {
                    case "+":
                        _result += secondOperand;
                        break;
                    case "-":
                        _result -= secondOperand;
                        break;
                    case "*":
                        _result *= secondOperand;
                        break;
                    case "/":
                        if (secondOperand != 0)
                            _result /= secondOperand;
                        else
                            ResultTextBox.Text = "Error";
                        break;
                }
                ResultTextBox.Text = _result.ToString();
                _operation = string.Empty;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Text = string.Empty;
            _result = 0;
            _operation = string.Empty;
        }
    }
}
