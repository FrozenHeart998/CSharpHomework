using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program1
{
    public partial class Form3 : Form
    {
        private Order obj = null;
        public Form3()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public Form3(Order obj)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.obj = obj;
            textBox1.Text = obj.num;
            textBox2.Text = obj.name;
            textBox3.Text = obj.product;
            textBox4.Text = obj.cost;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OrderService.ChangeOrder(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, obj);
                DialogResult result = MessageBox.Show("修改成功", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch(Exception exception)
            {
                DialogResult result = MessageBox.Show(exception.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
