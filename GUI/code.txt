namespace KaracsonyGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool validNumber(string text)
        {
            if (int.TryParse(text, out int result))
                return true;

            return false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                label4.Text = "";
            }
            else
            {
                if (!validNumber(textBox1.Text))
                {
                    label4.Text = "Negatív számot nem adhat meg!";
                }
                else
                {
                    if (int.TryParse(textBox1.Text, out int number1) && int.TryParse(textBox2.Text, out int number2))
                    {
                        if (number2 > number1)
                        {
                            label4.Text = "Túl sok az eladott angyalka!";
                        }
                        else
                        {
                            label4.Text = "";
                        }
                    }
                }
            }
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {



            if (textBox2.Text == "")
            {
                label4.Text = "";

            }
            else
            {
                if (!validNumber(textBox2.Text))
                {
                    label4.Text = "Negatív számot nem adhat meg!";
                }
                else
                {
                    if (int.TryParse(textBox1.Text, out int number1) && int.TryParse(textBox2.Text, out int number2))
                    {
                        if (number2 > number1)
                        {
                            label4.Text = "Túl sok az eladott angyalka!";

                        }
                        else
                        {
                            label4.Text = "";
                        }
                    }
                }
            }





        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && int.TryParse(textBox1.Text, out int number1) && int.TryParse(textBox2.Text, out int number2))
            {
                if (number2 < number1)
                {
                    int kesz = int.Parse(textBox1.Text);

                    int elad = int.Parse(textBox2.Text);

                    int maradek = kesz - elad;

                    richTextBox1.Text += numericUpDown1.Value + ". nap:     +" + textBox1.Text + "\t-" + textBox2.Text + "\t=\t" + maradek + "\n";

                    if (numericUpDown1.Minimum < 40)
                    {
                        numericUpDown1.Minimum = numericUpDown1.Value + 1;
                    } else
                    {
                        button1.Enabled = false;
                    }

                    
                }
            }


        }
    }
}
