using System;
using System.Windows.Forms;

namespace program1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OrderService.AddOrder(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                DialogResult result = MessageBox.Show("添加成功", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
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
