using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace program1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OrderService.orders.Add(new Order("2017122099", "小明", "铅笔", "2", "13523689191"));
            OrderService.orders.Add(new Order("20160229193", "小红", "笔记本", "5", "18523648191"));
            OrderService.orders.Add(new Order("19980631588", "小军", "羽毛球", "5", "14523647991"));
            OrderService.orders.Add(new Order("20080808888", "小军", "羽毛球拍", "100", "13224566791"));
            OrderService.orders.Add(new Order("20101010999", "小刚", "羽毛球", "3", "1892395219"));
            OrderService.orders.Add(new Order("20101010999", "小刚", "羽毛球", "5", "18923954219"));
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bindingSource1.DataSource = OrderService.orders;
        }

        private void Update()
        {
            bindingSource1.DataSource = new List<Order>();
            bindingSource1.DataSource = OrderService.orders;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 addForm = new Form2();
            DialogResult result = addForm.ShowDialog();
            Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form3 changeForm = new Form3((Order)this.dataGridView1.CurrentRow.DataBoundItem);
                DialogResult result = changeForm.ShowDialog();
                dataGridView1.Invalidate();
            }
            catch
            {
                DialogResult result = MessageBox.Show("你没有选中订单", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("是否删除所选订单", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                try
                {
                    if (this.dataGridView1.SelectedRows.Count <= 0)
                    {
                        throw new Exception();
                    }
                    foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                    {
                        OrderService.DelOrder((Order)row.DataBoundItem);
                    }
                    Update();
                    DialogResult result = MessageBox.Show("删除成功", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    DialogResult result = MessageBox.Show("删除失败", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "订单号")
                {
                    bindingSource1.DataSource = OrderService.FindByNum(textBox1.Text);
                }
                else if (comboBox1.Text == "客户名")
                {
                    bindingSource1.DataSource = OrderService.FindByName(textBox1.Text);
                }
                else if (comboBox1.Text == "商品名")
                {
                    bindingSource1.DataSource = OrderService.FindByProduct(textBox1.Text);
                }
                else if (comboBox1.Text == "金额")
                {
                    bindingSource1.DataSource = OrderService.FindByCost(textBox1.Text);
                }
                else if (comboBox1.Text == "显示全部订单")
                {
                    bindingSource1.DataSource = OrderService.orders;
                }
            }
            catch
            {
                DialogResult result = MessageBox.Show("未找到订单", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bindingSource1.DataSource = OrderService.orders;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                OrderService.TestOrder();
                DialogResult result = MessageBox.Show("检索完毕，订单无问题", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                DialogResult result = MessageBox.Show("检索完毕，" + exception.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Update();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "请选择文件";
            openFileDialog.Filter = "所有文件(*xml*)|*.xml*";
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
                    OrderService.Import(xmlSerializer, fileName, OrderService.orders);
                    DialogResult result = MessageBox.Show("导入成功，并去除了不符合要求的订单", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                DialogResult result = MessageBox.Show("导入失败", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Update();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML文件（*.xml）|*.xml";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName.ToString();
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
                    OrderService.Export(xmlSerializer, fileName, OrderService.orders);
                }
                DialogResult result = MessageBox.Show("保存成功", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                DialogResult result = MessageBox.Show("保存失败", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "请选择文件";
            openFileDialog.Filter = "所有文件(*xml*)|*.xml*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                OrderService.ConvertToHTMLAndOpen(fileName);
            }
        }
    }
}