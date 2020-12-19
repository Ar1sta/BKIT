using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using LibraryLab5;

namespace Laba4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        List<string> Spisok = new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog A = new OpenFileDialog();
            Stopwatch watch = new Stopwatch();
            A.Filter = "Текстовые файлы|*.txt";
            if (A.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Необходимо выбрать файл");
                return;
            }
            watch.Start();
            string text = File.ReadAllText(A.FileName);
            char[] razdeliteli = { '—','-', '?', '!',  ' ', ',', '.', ':', '\t','\n' };
            //text=text.Trim(razdeliteli);
            string[] words = text.Split(razdeliteli);
            foreach (string word in words)
            {
                if (!String.IsNullOrEmpty(word))
                    if (!Spisok.Contains(word))
                        Spisok.Add(word);
            }
            watch.Stop();
            this.textBox1.Text = watch.Elapsed.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.textBox2.Text)&&Spisok.Count > 0)
            {
                this.listBox1.Items.Clear();
                Stopwatch watch = new Stopwatch();
                string Word = this.textBox2.Text;
                this.listBox1.BeginUpdate();
                bool a = false;
                watch.Start();
                foreach (string word in Spisok)
                {
                    if (word.Contains(Word))
                    {
                        this.listBox1.Items.Add(word);
                        a = true;
                    }
                }
                watch.Stop();
                if (a == false)
                    this.listBox1.Items.Add("Не найдено совпадений");
                this.listBox1.EndUpdate();
                this.textBox3.Text = watch.Elapsed.ToString();
            }
            else if (String.IsNullOrEmpty(this.textBox2.Text) && Spisok.Count == 0)
            {
                MessageBox.Show("Необходимо отрыть файл и выбрать слово для поиска");
            }
            else if (String.IsNullOrEmpty(this.textBox2.Text))
            {
                MessageBox.Show("Необходимо выбрать слово для поиска");
            }
            else if (Spisok.Count == 0)
            {
                MessageBox.Show("Необходимо отрыть файл");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.textBox4.Text))
            {
                if (!String.IsNullOrEmpty(this.textBox2.Text) && Spisok.Count > 0)
                {
                    this.listBox1.Items.Clear();
                    Stopwatch watch = new Stopwatch();
                    string Word = this.textBox2.Text;
                    string Max = this.textBox4.Text;
                    int max = int.Parse(Max);
                    this.listBox1.BeginUpdate();
                    watch.Start();
                    foreach (string word in Spisok)
                    {
                        if (DistanceClass.Distance(word, Word) <= max)
                        {
                            this.listBox1.Items.Add(word);  
                        }
                    }
                    watch.Stop();
                    this.listBox1.EndUpdate();
                    this.textBox3.Text = watch.Elapsed.ToString();
                }
                else if (String.IsNullOrEmpty(this.textBox2.Text) && Spisok.Count == 0)
                {
                    MessageBox.Show("Необходимо отрыть файл и выбрать слово для поиска");
                }
                else if (String.IsNullOrEmpty(this.textBox2.Text))
                {
                    MessageBox.Show("Необходимо выбрать слово для поиска");
                }
                else if (Spisok.Count == 0)
                {
                    MessageBox.Show("Необходимо отрыть файл");
                }
                
            }
            else 
            {
                MessageBox.Show("Необходимо ввести максимальное расстояние");
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }


    }
}
