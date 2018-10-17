using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Graphics graphics;
        private Pen pen = new Pen(Color.Blue);
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        double k1 = 1;
        double k2 = 1;

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null)
            {
                graphics = this.CreateGraphics();
            }
            else
            {
                return;
            }

            setData();
            setPen();

            drawCayleyTree(10, 350, 450, 100, -Math.PI / 2);
        }

        void random()
        {
            Random randomNum = new Random();
            randomNum.Next();
            textBox1.Text = randomNum.Next(0, 180).ToString();
            textBox2.Text = randomNum.Next(0, 180).ToString();
            textBox3.Text = randomNum.NextDouble().ToString();
            textBox4.Text = randomNum.NextDouble().ToString();
            textBox5.Text = (randomNum.NextDouble() * 4).ToString();
            textBox6.Text = randomNum.NextDouble().ToString();
            textBox7.Text = randomNum.NextDouble().ToString();
            int num = randomNum.Next(1, 8);
            comboBox1.Text = comboBox1.Items[num].ToString();
        }

        void setData()
        {
            if (double.TryParse(textBox1.Text, out double num1) == true)
            {
                th1 = num1 * Math.PI / 180;
            }
            else
            {
                th1 = 30 * Math.PI / 180;
            }
            if (double.TryParse(textBox2.Text, out double num2) == true)
            {
                th2 = num2 * Math.PI / 180;
            }
            else
            {
                th2 = 20 * Math.PI / 180;
            }
            if (double.TryParse(textBox3.Text, out double num3) == true)
            {
                per1 = num3;
            }
            else
            {
                per1 = 0.6;
            }
            if (double.TryParse(textBox4.Text, out double num4) == true)
            {
                per2 = num4;
            }
            else
            {
                per2 = 0.7;
            }
            if (double.TryParse(textBox6.Text, out double num5) == true)
            {
                if (num5 > 1 || num5 <= 0)
                {
                    num5 = 1;
                }
                k1 = num5;
            }
            else
            {
                k1 = 1;
            }
            if (double.TryParse(textBox7.Text, out double num6) == true)
            {
                if (num6 > 1 || num6 <= 0)
                {
                    num6 = 1;
                }
                k2 = num6;
            }
            else
            {
                k2 = 1;
            }
        }

        void setPen()
        {
            if (comboBox1.Text == "七彩")
            {
                Random randomColor = new Random();
                int randomNum = randomColor.Next(1, 8);
                if (comboBox1.Items[randomNum].ToString() == "蓝色")
                {
                    pen.Color = Color.Blue;
                }
                else if (comboBox1.Items[randomNum].ToString() == "红色")
                {
                    pen.Color = Color.Red;
                }
                else if (comboBox1.Items[randomNum].ToString() == "黑色")
                {
                    pen.Color = Color.Black;
                }
                else if (comboBox1.Items[randomNum].ToString() == "粉色")
                {
                    pen.Color = Color.Pink;
                }
                else if (comboBox1.Items[randomNum].ToString() == "绿色")
                {
                    pen.Color = Color.Green;
                }
                else if (comboBox1.Items[randomNum].ToString() == "黄色")
                {
                    pen.Color = Color.Yellow;
                }
                else if (comboBox1.Items[randomNum].ToString() == "紫色")
                {
                    pen.Color = Color.Purple;
                }
            }
            else
            {
                if (comboBox1.Text == "蓝色")
                {
                    pen.Color = Color.Blue;
                }
                else if (comboBox1.Text == "红色")
                {
                    pen.Color = Color.Red;
                }
                else if (comboBox1.Text == "黑色")
                {
                    pen.Color = Color.Black;
                }
                else if (comboBox1.Text == "粉色")
                {
                    pen.Color = Color.Pink;
                }
                else if (comboBox1.Text == "绿色")
                {
                    pen.Color = Color.Green;
                }
                else if (comboBox1.Text == "黄色")
                {
                    pen.Color = Color.Yellow;
                }
                else if (comboBox1.Text == "紫色")
                {
                    pen.Color = Color.Purple;
                }
            }

            if (float.TryParse(textBox5.Text, out float num) == true)
            {
                pen.Width = num;
            }
            else
            {
                pen.Width = 1;
            }
        }

        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0)
            {
                return;
            }
            if (checkBox1.Checked)
            {
                random();
                setData();
                setPen();
            }
            else
            {
                setPen();
            }

            double tempX = x0 + leng * Math.Cos(th);
            double tempY = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, tempX, tempY);

            double x1 = x0 + leng * Math.Cos(th) * k1;
            double y1 = y0 + leng * Math.Sin(th) * k1;

            double x2 = x0 + leng * Math.Cos(th) * k2;
            double y2 = y0 + leng * Math.Sin(th) * k2;

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (graphics != null)
            {
                graphics.Clear(this.BackColor);
                graphics.Dispose();
                graphics = null;
            }
        }
    }
}
