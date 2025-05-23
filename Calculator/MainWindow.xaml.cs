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
            if (OpScreen.Text.Contains("=") == true) 
            { 
                OpScreen.Clear(); 
                InputScreen.Clear(); 
            }
            if (InputScreen.Text == "0") InputScreen.Text = b.Content.ToString();
            else InputScreen.Text += b.Content.ToString();
            if (operation == "") num1 = double.Parse(InputScreen.Text);
            else num2 = double.Parse(InputScreen.Text);
               
            OpScreen.Text += b.Content.ToString();
        }

        private void MathOp_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if(OpScreen.Text.Contains("=")) OpScreen.Text = res.ToString();
            operation = b.Content.ToString();
            CheckOperation();   
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (OpScreen.Text.Contains("=") || OpScreen.Text == res.ToString())
            {
                OpScreen.Clear() ;
                OpScreen.Text = res.ToString();
            }
            else
            {
                if (OpScreen.Text.EndsWith(operation) == false)
                {
                    num2 = double.Parse(InputScreen.Text);
                    Calc();
                    if (operation == "") InputScreen.Clear();
                    OpScreen.AppendText("=");
                    InputScreen.Text = res.ToString();
                    OpScreen.Text += InputScreen.Text;
                }
                else res = num1;
            }
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            //This condition checks if the text is not null, while the text do not contain a decimal point
            //already and if the text itself ends with a decimal point, so the calculator will not allow the user
            //to add another decimal point in the same number value.
            if (InputScreen.Text != "" && InputScreen.Text.EndsWith(".") == false && InputScreen.Text.Contains(".") == false)
            {
                InputScreen.AppendText(".");
                OpScreen.AppendText(".");
            }
            else return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            switch (b.Content.ToString()) 
            {
                case "C": //OK
                    num1 = 0;
                    num2 = 0;
                    operation = "";
                    InputScreen.Clear();
                    OpScreen.Clear();
                    break;
                case "CE": 
                    break;
                case "DEL":  
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
            OpScreen.Text += InputScreen.Text;
        }

        private void Calc() 
        {
            switch (operation)
            {
                case "+":
                    res = num1 + num2;
                    operation = "";
                    break;
                case "-":
                    res = num1 - num2;
                    operation = "";
                    break;
                case "*":
                    res = num1 * num2;
                    operation = "";
                    break;
                case "/":
                    if (num2 == 0) //Checking the second number for division by 0
                    {
                        res = num1; //If divide by 0, then result will be equals to num1
                        operation = "";
                    }
                    else 
                    {
                        res = num1 / num2;
                        operation = "";
                    }
                    break;
                case "%":
                    res = (num1 * num2) / 100;
                    operation = "";
                    break;
                default:
                    break;
            }
            num1 = res;
            InputScreen.Text = num1.ToString();
        }
    }
}
