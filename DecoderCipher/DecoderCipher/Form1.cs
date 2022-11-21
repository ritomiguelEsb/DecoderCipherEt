using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DecoderCipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string finalText = "";
        int loop = 0;
        Random random;
        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.ForeColor = Color.Black;
            progressBar1.Value = 0;
            finalText = "";
            random = new Random();
            int change;
            try
            {
                change = Convert.ToInt32(textBox2.Text);
                change = -change + 26;
            }
            catch
            {
                change = 1;
            }
            for (int i = 0; i < change; i++)
            {
                if (finalText== "")
                {
                    foreach (char letterfor in textBox1.Text)
                    {
                        change_Letter(letterfor);
                    }
                }
                else
                {
                    string textToChange = finalText;
                    finalText = "";
                    foreach (char letterfor in textToChange)
                    {
                        change_Letter(letterfor);
                    }
                }
            }
            timer1.Enabled = true;
           
        }

        private void change_Letter(char letterfor)
        {

                int letter = char.ToLower(letterfor);
                char finalLetter;
                if(!char.IsLetter(letterfor))
                {
                    finalText += (char)32;
                    return;
                }
                if (letter + 1 > 122)
                {
                    finalLetter = (char)(letter - 25);
                }
                else
                {
                    finalLetter = (char)(letter + 1);
                }
                if (char.IsUpper(letterfor))
                {
                    finalText += char.ToUpper(finalLetter);
                }
                else
                {
                    finalText += finalLetter;

                }
                
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if(loop < 500)
            {
                textBox3.Clear();
                foreach(char rand in textBox1.Text)
                {
                    int num = random.Next(33, 126);
                    textBox3.Text += (char)(num);
                }
                progressBar1.Maximum = 500;
                progressBar1.Value += 1;
                loop++;
            }
            else
            {
                int num = random.Next(33, 126);
                timer1.Enabled = false;
                textBox3.Clear();
                
                textBox3.Text = finalText;
                loop = 0;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
