using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace counter2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // 获取用户输入的两个数字
            double num1 = double.Parse(txtNum1.Text);
            double num2 = double.Parse(txtNum2.Text);

            // 获取用户选择的运算符
            string op = cmbOperator.SelectedItem.ToString();

            // 根据运算符计算结果
            double result = 0;
            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
            }

            // 将结果显示在标签控件中
            lblResult.Text = result.ToString();
        }
    }
}
