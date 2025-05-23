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

namespace Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InputScreen.Text = "0";
        }

        public string operation = "";
        public double num1;
        public double num2;
        public double res;
        private void Number_Click(object sender, RoutedEventArgs e) //OK
        {
            Button b = (Button)sender;
            if (InputScreen.Text == operation) InputScreen.Clear();
            if (InputScreen.Text == "0") InputScreen.Text = b.Content.ToString();
            else InputScreen.Text += b.Content.ToString();
            if (operation == "") num1 = double.Parse(InputScreen.Text); 
            else num2 = double.Parse(InputScreen.Text);
        }

        private void MathOp_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Content.ToString();
            CheckOperation();   
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            num2 = double.Parse(InputScreen.Text);
            Calc();
            if (operation == "") InputScreen.Clear();
            InputScreen.Text = res.ToString();  
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            //This condition checks if the text is not null, while the text do not contain a decimal point
            //already and if the text itself ends with a decimal point, so the calculator will not allow the user
            //to add another decimal point in the same number value.
            if (InputScreen.Text != "" && InputScreen.Text.EndsWith(".") == false && InputScreen.Text.Contains(".") == false)
            {
                InputScreen.AppendText(".");
            }
            else return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            switch (b.Content.ToString()) 
            {
                case "C": //Resets every value, and the screen text
                    num1 = 0;
                    num2 = 0;
                    operation = "";
                    OpScreen.Clear();
                    InputScreen.Clear();
                    break;
                case "CE": //Resets the last value entry
                    if (operation == "") num1 = 0;
                    else num2 = 0;
                    InputScreen.Clear();
                    break;
                case "DEL": //Deletes the last character input unless the last value is the operation's result
                    try
                    {
                        InputScreen.Undo();
                        if (operation == "")
                        {
                            num1 = double.Parse(InputScreen.Text);
                            InputScreen.Text = num1.ToString();
                        }
                        else
                        {
                            num2 = double.Parse(InputScreen.Text);
                            InputScreen.Text = num2.ToString();
                        }
                    }
                    catch 
                    { 
                        InputScreen.Clear();
                        OpScreen.Clear();
                        num1 = 0;
                        num2 = 0;
                        operation = "";
                    }
                    break;
                default:
                    break;
            }
        }
        private void CheckOperation() 
        {
            switch (operation) 
            {
                case "+":
                    InputScreen.Text = operation;
                    break;
                case "-":
                    InputScreen.Text = operation;
                    break;
                case "*":
                    InputScreen.Text = operation;
                    break;
                case "/":
                    InputScreen.Text = operation;
                    break;
                case "%":
                    InputScreen.Text = operation;
                    break;
                default:
                    break;
            }
        }

        private void Calc() 
        {
            switch (operation)
            {
                case "+":
                    res = num1 + num2;
                    break;
                case "-":
                    res = num1 - num2;
                    break;
                case "*":
                    res = num1 * num2;
                    break;
                case "/":
                    //Checking the second number for division by 0
                    if (num2 == 0) res = num1; //If divide by 0, then result will be equals to num1
                    else res = num1 / num2;
                    res = Math.Round(res,2); //Shows inly two digits on a decimal number
                    break;
                case "%":
                    res = (num1 * num2) / 100;
                    break;
                default:
                    break;
            }
            OpScreen.Text = res.ToString();
            num1 = res;
            operation = "";
        }
    }
}
