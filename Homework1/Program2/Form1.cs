using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs eventArgs)
        {
            try
            {
                string NumberOneStr = this.textBox1.Text;
                string NumberTwoStr = this.textBox2.Text;
                float NumberOne = float.Parse(NumberOneStr);
                float NumberTwo = float.Parse(NumberTwoStr);
                this.label1.Text = "计算结果为：" + (NumberOne * NumberTwo);
            }
            catch
            {
                this.label1.Text = "输入有误，请重新输入。";
            }
        }
    }
}
