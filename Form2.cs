using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace Win_dog
{
    public partial class Form2 : Form
    {
        bool ds = false;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds = true;
            button1.Enabled = false;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds= false;
            button1.Enabled = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            DateTime dt =DateTime.Now;
            if (this.Visible == true)
            {
                this.label1.Text = "当前时间：" + string.Format("{0:T}", dt);
            }
            if (ds == true)
            {
                if (numericUpDown1.Value == dt.Hour)
                {
                    if (numericUpDown2.Value == dt.Minute)
                    {
                        if (numericUpDown3.Value == dt.Second)
                        {
                            Thread th = new Thread(new ThreadStart(showmsg));
                            th.Start();
                        }
                    }
                }
            }
        }
        private void showmsg()
        {


            if (checkBox1.Checked == true) {
                
                System.Diagnostics.Process.Start(@"C:\Windows\System32\Shutdown.exe"," -s -t 10");
                MessageBox.Show("十秒后关机！", "定时提示");
            }
            else
            {
                if (textBox1.Text == "输入提示内容") { MessageBox.Show("时间到！"); }
                else { MessageBox.Show(textBox1.Text, "定时提示"); }
            }
            ds = false;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
             e.Cancel = true;
         
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "输入提示内容") { textBox1.Text = ""; }
        }
    }
}
