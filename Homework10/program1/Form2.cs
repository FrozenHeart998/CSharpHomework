using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program1
{
    public partial class Form2 : Form
    {
        private Order currentOrder { get; set; }
        private bool isAdd { get; set; }
        static private int count = 0;

        public Form2()
        {
            InitializeComponent();
            count = 0;
        }

        public Form2(Order order)
        {
            InitializeComponent();
            count = 0;
            if (order == null)
            {
                isAdd = true;
                currentOrder = new Order();
            }
            else
            {
                isAdd = false;
                currentOrder = order;
            }
            orderBindingSource.DataSource = currentOrder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAdd)
                {
                    if (IsRightOrderNum(currentOrder.num))
                    {
                        OrderService.AddOrder(currentOrder);
                        MessageBox.Show("添加成功", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    if (IsRightOrderNum(currentOrder.num))
                    {
                        OrderService.ChangeOrder(currentOrder);
                        MessageBox.Show("修改成功", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                this.Close();
            }
            catch
            {
                if (isAdd)
                {
                    MessageBox.Show("添加失败", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("修改失败", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsRightOrderNum(string num)
        {
            String numTest = @"^(?<year>[0-9]{4})(?<month>[0-9]{2})(?<day>[0-9]{2})[0-9]{3}$";
            Match numMatch = Regex.Match(num, numTest);

            int year = int.Parse(numMatch.Result("${year}"));
            int month = int.Parse(numMatch.Result("${month}"));
            int day = int.Parse(numMatch.Result("${day}"));

            if (month > 12)
            {
                return false;
            }
            else if (month == 2)
            {
                if (year % 4 == 0 && ((year % 100 != 0) || (year % 4 == 400)))
                {
                    if (day > 29)
                    {
                        return false;
                    }
                }
                else
                {
                    if (day > 28)
                    {
                        return false;
                    }
                }
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                if (day > 30)
                {
                    return false;
                }
            }
            else if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                if (day > 31)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
