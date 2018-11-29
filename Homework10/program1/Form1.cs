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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ordersBindingSource.DataSource = OrderService.GetAllOrders();
        }

        private void Update()
        {
            ordersBindingSource.DataSource = OrderService.GetAllOrders();
            ordersBindingSource.ResetBindings(false);
            productsBindingSource.ResetBindings(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindOrders();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(ordersBindingSource.Current!=null)
            {
                OrderService.DeletOrder((Order)ordersBindingSource.Current);
                MessageBox.Show("删除成功", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Update();
            }
            else
            {
                MessageBox.Show("删除失败", "提醒", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(null);
            form.ShowDialog();
            Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(ordersBindingSource.Current!=null)
            {
                Form2 form = new Form2((Order)ordersBindingSource.Current);
                form.ShowDialog();
                Update();
            }
            else
            {
                MessageBox.Show("修改失败", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FindOrders()
        {
            List<Order> tempOrders;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    tempOrders = OrderService.FindByNum(textBox1.Text);
                    break;
                case 1:
                    tempOrders = OrderService.FindByName(textBox1.Text);
                    break;
                case 2:
                    tempOrders = OrderService.FindByPhone(textBox1.Text);
                    break;
                case 3:
                    tempOrders = OrderService.FindByProduct(textBox1.Text);
                    break;
                case 4:
                    tempOrders = OrderService.FindByCost(textBox1.Text);
                    break;
                default:
                    tempOrders = OrderService.GetAllOrders();
                    break;
            }
            if(tempOrders.Count!=0)
            {
                ordersBindingSource.DataSource = tempOrders;
            }
            else
            {
                MessageBox.Show("未查询到订单", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ordersBindingSource.ResetBindings(false);
            productsBindingSource.ResetBindings(false);
        }
    }
}
