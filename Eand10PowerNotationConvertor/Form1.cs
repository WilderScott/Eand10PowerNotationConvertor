using System.Diagnostics;
using System.Windows.Forms;

namespace Eand10PowerNotationConvertor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = SanatizeInput(textBox1.Text);
            RemoveNotation();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = SanatizeInput(textBox3.Text);
            RemoveNotation();
        }

        private void RemoveNotation()
        {
            if (textBox1.Text != "" && textBox3.Text != "" && textBox1.Text != "-" && textBox3.Text != "-" && textBox1.Text != "." && textBox3.Text != ".")
            {
                double coefficient = double.Parse(textBox1.Text);
                double exponent = double.Parse(textBox3.Text);
                coefficient *= Math.Pow(10, exponent);
                textBox2.Text = coefficient.ToString("0." + new string('#', 339)); // Have to do this to avoid the result being in E notation
            }
            else
            {
                textBox2.Text = "";
            }
        }
        private String SanatizeInput(String text)
        {
            int i = 0;
            bool decimalPointAlreadyUsed = false;

            foreach (char character in text)
            {
                if (!Char.IsDigit(character))
                {
                    if (character == '-' && i == 0)
                    {

                    }
                    else if (character == '.')
                    {
                        if (decimalPointAlreadyUsed)
                        {
                            text = text.Remove(i, 1);
                        }
                        else
                        {
                            decimalPointAlreadyUsed = true;
                        }
                    }
                    else
                    {
                        text = text.Remove(i, 1);
                    }
                }
                i++;
            }
            return text;
        }
    }
}
