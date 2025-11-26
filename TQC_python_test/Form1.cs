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

namespace TQC_python_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> P_list = new List<string>();//題目清單
        int min = 0, sec = 0, n = 0;
        private void button1_Click(object sender, EventArgs e)//開始測試
        {
            min = 100; sec = 0;
            timer1.Start();
            Random r = new Random();
            
            for (int i = 0; i < 9; i++)
            {
                int rn = r.Next(1,11);
                string f = "";
                if (rn < 10)
                {
                   f = "0" + rn.ToString();
                }
                else if(rn == 10)
                {
                    P_list.Add("PYD" + (i + 1).ToString() + "10");
                    continue;
               }
                 P_list.Add("PYD" + (i + 1).ToString() + $"{f.ToString()}");
            }
            StreamReader s = new StreamReader($"./TQC-Problem-list/{P_list[n]}.txt");
            textBox3.Text = s.ReadToEnd();
            s.Close();
            label3.Text = $"第{n + 1}/{P_list.Count()}題";
        }

        private void button2_Click(object sender, EventArgs e)//退出
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)//第一題
        {
            n = 0;
            StreamReader s = new StreamReader($"./TQC-Problem-list/{P_list[n]}.txt");
            textBox3.Text = s.ReadToEnd();
            s.Close();
            label3.Text = $"第{n + 1}/{P_list.Count()}題";

        }

        private void button4_Click(object sender, EventArgs e)//上一題
        {
            if (n - 1 >= 0)
            {
                n--;
                StreamReader s = new StreamReader($"./TQC-Problem-list/{P_list[n]}.txt");
                textBox3.Text = s.ReadToEnd();
                s.Close();
                label3.Text = $"第{n + 1}/{P_list.Count()}題";
            }

        }

        private void button5_Click(object sender, EventArgs e)//下一題
        {
            if (n + 1 < P_list.Count())
            {
                n++;
                StreamReader s = new StreamReader($"./TQC-Problem-list/{P_list[n]}.txt");
                textBox3.Text = s.ReadToEnd();
                s.Close();
                label3.Text = $"第{n + 1}/{P_list.Count()}題";
            }
        }

        private void button6_Click(object sender, EventArgs e)//最後一題
        {
            n = P_list.Count() - 1;
            StreamReader s = new StreamReader($"./TQC-Problem-list/{P_list[n]}.txt");
            textBox3.Text = s.ReadToEnd();
            s.Close();
            label3.Text = $"第{n + 1}/{P_list.Count()}題";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sec != 0)
            {
                sec--;
                textBox2.Text = sec.ToString();

            }
            else
            {
                if (min != 0)
                {
                    min--;
                    sec = 59;
                    textBox1.Text = min.ToString();
                    textBox2.Text = sec.ToString();
                }
                else
                {
                    timer1.Stop();
                    MessageBox.Show("時間到，測試結束!");
                    //結束測試
                }
            }
        }
    }
}
