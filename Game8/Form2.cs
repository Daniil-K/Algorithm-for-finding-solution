using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game8
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            string prov = textBox1.Text;
            Form1.vhod = textBox1.Text;
            Form1.vyhod = textBox2.Text;
            for (int i = 0; i < prov.Length - 1; i++)
            {
                for (int j = i + 1; j < prov.Length; j++)
                {
                    if (Convert.ToInt32(prov[i]) > Convert.ToInt32(prov[j]))
                    {
                        if (prov[j] == '0')
                        {
                            continue;
                        }
                        else
                        {
                            count++;
                        }
                    }
                }
            }
            if (prov[0] == '0' || prov[1] == '0' || prov[2] == '0')
            {
                count += 1;
            }
            if (prov[3] == '0' || prov[4] == '0' || prov[4] == '0')
            {
                count += 2;
            }
            if (prov[6] == '0' || prov[7] == '0' || prov[8] == '0')
            {
                count += 3;
            }
            System.Console.WriteLine("Count: " + count);
            if (count % 2 == 1)
                MessageBox.Show("Решения не существует", "Ошибка");
            this.Hide();
        }
    }
}
