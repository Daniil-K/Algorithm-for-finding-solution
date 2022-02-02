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
    public partial class Form1 : Form
    {
        public static string vhod;
        public static string vyhod;
        List<string> list = new List<string>();
        int p = -1;
        bool igra;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ввестиДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private async void начатьToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            refresh(vhod);
            System.Console.WriteLine(vhod);
            list.Add(vhod);
            await Task.Delay(500);
            resulAsync();
        }

        private void refresh(string mas)
        {
            for (int z = 0; z < mas.Length; z++)
            {
                button(z).Text = mas[z].ToString();
                if (mas[z] == '0')
                    button(z).Visible = false;
            }
        }

        private Label button(int position)
        {
            switch (position)
            {
                case 0: return label0;
                case 1: return label1;
                case 2: return label2;
                case 3: return label3;
                case 4: return label4;
                case 5: return label5;
                case 6: return label6;
                case 7: return label7;
                case 8: return label8;
                default: return null;

            }
        }

        private async void resulAsync()
        {
            int zad = 50;
            do
            {
                p++;
                System.Console.WriteLine(p.ToString());
                for (int i = 0; i < 4; i++)
                {
                    string mas = list[p];
                    for (int z = 0; z < mas.Length; z++)
                    {
                        button(z).Visible = true;
                    }
                    int b = p;
                    if (i == 0)
                    {
                        for (int j = 0; j < mas.Length; j++)
                        {
                            button(j).Visible = true;
                            if (mas[j] == '0')
                            {
                                if (j == 0 || j == 3 || j == 6)
                                    break;
                                char k = mas[j - 1];
                                char n = mas[j];
                                mas = mas.Replace(n, '9').Replace(k, n).Replace('9', k);
                                j = 9;
                            }
                        }
                        list.Add(mas);
                        refresh(mas);
                        check();
                        if (igra == true)
                            i = 4;
                        await Task.Delay(zad);
                    }

                    if (i == 1)
                    {
                        for (int j = 0; j < mas.Length; j++)
                        {
                            button(j).Visible = true;
                            if (mas[j] == '0')
                            {
                                if (j == 0 || j == 1 || j == 2)
                                    break;
                                char k = mas[j - 3];
                                char n = mas[j];
                                mas = mas.Replace(n, '9').Replace(k, n).Replace('9', k);
                                j = 9;
                            }
                        }
                        list.Add(mas);
                        refresh(mas);
                        check();
                        if (igra == true)
                            i = 4;
                        await Task.Delay(zad);
                    }

                    if (i == 2)
                    {
                        for (int j = 0; j < mas.Length; j++)
                        {
                            button(j).Visible = true;
                            if (mas[j] == '0')
                            {
                                if (j == 2 || j == 5 || j == 8)
                                    break;
                                char k = mas[j + 1];
                                char n = mas[j];
                                mas = mas.Replace(n, '9').Replace(k, n).Replace('9', k);
                                j = 9;
                            }
                        }
                        list.Add(mas);
                        refresh(mas);
                        check();
                        if (igra == true)
                            i = 4;
                        await Task.Delay(zad);
                    }

                    if (i == 3)
                    {
                        for (int j = 0; j < mas.Length; j++)
                        {
                            button(j).Visible = true;
                            if (mas[j] == '0')
                            {
                                if (j == 6 || j == 7 || j == 8)
                                    break;
                                char k = mas[j + 3];
                                char n = mas[j];
                                mas = mas.Replace(n, '9').Replace(k, n).Replace('9', k);
                                j = 9;
                            }
                        }
                        list.Add(mas);
                        refresh(mas);
                        check();
                        if (igra == true)
                            i = 4;
                        await Task.Delay(zad);
                    }
                    for (int r = 0; r < list.Count - 1; r++)
                    {
                        for (int t = r + 1; t < list.Count; t++)
                        {
                            if (list[r] == list[t])
                                list.RemoveAt(t);
                        }
                    }
                }
            }
            while (igra != true);
        }

        private void check()
        {
            for (int q = 0; q < list.Count; q++)
            {
                if (vyhod == list[q])
                {
                    MessageBox.Show("Целевая вершина: " + (p+1) + "\n" + "Конечная вершина: " + (q+1), "Победа");
                    igra = true;
                    for (q = 0; q < list.Count; q++)
                        System.Console.WriteLine((q+1) + ": " +  list[q]);
                }
            }
        }
    }
}
