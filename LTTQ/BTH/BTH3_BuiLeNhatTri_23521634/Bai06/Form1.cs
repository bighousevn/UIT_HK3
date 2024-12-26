using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai06
{
    public partial class Form1 : Form
    {

        Boolean isOperationPerformed = true;
        double resultValue = 0;
        string currentOperator;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((inputBox.Text == "0") || (isOperationPerformed))
                inputBox.Clear();
            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!inputBox.Text.Contains("."))
                    inputBox.Text = inputBox.Text + button.Text;
            }
            else inputBox.Text = inputBox.Text + button.Text;
        }
        private void butttonCE_Click(object sender, EventArgs e)
        {
            inputBox.Text = "0";
        }
        private void butttonC_Click(object sender, EventArgs e)
        {
            inputBox.Text = "0";
            resultValue= 0;
            result.Text = "";
        }
        private void butttonBS_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(inputBox.Text)) inputBox.Text=inputBox.Text.Remove(inputBox.Text.Length - 1);
            
        }
        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(resultValue==0)
            {
                currentOperator=button.Text; 
                resultValue=float.Parse(inputBox.Text);
                result.Text=inputBox.Text+" "+ currentOperator;
                isOperationPerformed=true;     
            }
            else
            {
                equalButton.PerformClick();
                currentOperator = button.Text;
                result.Text = inputBox.Text + " " + currentOperator;
                isOperationPerformed = true;                
            }
        }
        private void equalButton_Click(object sender, EventArgs e)
        {
            
            switch(currentOperator)
            {
                case "+":
                    inputBox.Text = (resultValue + Double.Parse(inputBox.Text)).ToString();
                    break;
                case "-":
                    inputBox.Text = (resultValue - Double.Parse(inputBox.Text)).ToString();
                    break;
                case "*":
                    inputBox.Text = (resultValue * Double.Parse(inputBox.Text)).ToString();
                    break;
                case "/":
                    inputBox.Text = (resultValue / Double.Parse(inputBox.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = float.Parse(inputBox.Text);
            result.Text = "";
            currentOperator = "";
        }
    }
}
