using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Win_dog
{
    public partial class Form1 : Form
    {
        int i = 0;
        bool move_dog = true;//true小狗移动
        bool movein_dog = false;
        Color huise = Color.FromArgb(153, 153, 153);
        private  int screen_x = System.Windows.Forms.SystemInformation.VirtualScreen.Width;
        private  int screen_y = System.Windows.Forms.SystemInformation.VirtualScreen.Height;
        Form2 f = new Form2();
        #region 移动方向
        int x = 3;
        int y=1;
        #endregion
        public Form1()
        {
            InitializeComponent();
        }
        #region 移动窗体
        Point mx = new Point();
        private bool move_this = false;
        private void m_move(MouseEventArgs e)
        {
            if (move_this == true)
            {
                Point fx = new Point();
                Point nmx = new Point();
                nmx = e.Location;
                int dx, dy;
                dx = nmx.X - mx.X;
                dy = nmx.Y - mx.Y;
                fx.X = this.Location.X + dx;
                fx.Y = this.Location.Y + dy;
                this.Location = fx;
            }
        }
        private void m_down(MouseEventArgs e)
        {
            move_this = true;
            mx = e.Location;
        }
        private void m_up()
        {
            move_this = false;
            if (this.Location.X < 50) {
                this.Location = new Point(this.Location.X+50,this.Location.Y);
            }
            if (this.Location.Y > screen_y - 90) { this.Location = new Point(this.Location.X , this.Location.Y- 95); }
            if (this.Location.X > screen_x - 80) { this.Location = new Point(this.Location.X- 85, this.Location.Y ); }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            m_down(e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            m_move(e);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            m_up();
        }
       

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {//PointToClient( System.Windows.Forms .Control.MousePosition);//
           // textBox1.Text = System.Windows.Forms.Control.MousePosition.ToString();
            int dog_x = this.Location.X;
            int dog_y = this.Location.Y;
            if (move_dog == true && movein_dog == false)
            {
                Point p = this.Location;
                p.X = p.X + x;
                p.Y = p.Y + y;
                this.Location = p;
            }
            if (x > 0)
                {
                    if (i >= 4) { i = 0; }
                    else
                    { i = i + 1; }
                }
                else
                {
                    if (i <4|i==9) { i = 5; }
                    else
                    { i = i + 1; }
                }
            if (this.Location.X < 0) { x = -x; }
            if (this.Location.X + this.Width > screen_x)
            {
                x = -x;
            }
            if (this.Location.Y < 0) { y = -y; }
            if (this.Location.Y + this.Height > screen_y){  y = -y; }
                pictureBox1.BackgroundImage = imageList1.Images[i];
                Bitmap b = this.pictureBox1.BackgroundImage as Bitmap;
                b.MakeTransparent(huise);
                this.label1.Text = "时间：" + string.Format("{0:T}", DateTime.Now);
               // this.label1.Text = " 时间："+ DateTime.Now.ToShortTimeString();
        }



        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            movein_dog = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            movein_dog = false;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 固定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (固定ToolStripMenuItem.Checked==true)
            {
                固定ToolStripMenuItem.Checked=false;
                timer1.Enabled = true;
                move_dog = true;
                label1.Visible =true;
            }
            else{
            move_dog = false;
            timer1.Enabled = false;
            pictureBox1.BackgroundImage = imageList1.Images[10];
            Bitmap b = this.pictureBox1.BackgroundImage as Bitmap;
            b.MakeTransparent(huise);
            固定ToolStripMenuItem.Checked=true;
            label1.Visible = false ;
            }
        }

        //private void 移动ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    move_dog = true;
        //    timer1.Enabled = true;
        //}

        private void contextMenuStrip1_VisibleChanged(object sender, EventArgs e)
        {
            if (contextMenuStrip1.Visible == true)
            {  timer1.Enabled = false;}
            else
            {
                if (move_dog == true)
                    timer1.Enabled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Goosoz","Hi");
            System.Diagnostics.Process.Start("http://hi.baidu.com/goosoz");
        }

        private void 定时ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            f.Show();
        }


    }
}
