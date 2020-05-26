using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoilData
{
    public partial class ZhuCe : Form
    {
        public ZhuCe()
        {
            InitializeComponent();
            this.Key1_box.GotFocus += Key1_box_GotFocus;
            this.Key2.GotFocus += Key1_box_GotFocus;

            foreach (Control control in this.Controls)
            {
                if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    TextBox textBox = (TextBox)control;
                    textBox.GotFocus += box_GotFocus;
                }
            }
            foreach (Control control in this.groupBox1.Controls)
            {
                if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    TextBox textBox = (TextBox)control;
                    textBox.GotFocus += box_GotFocus;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要取消吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
            else
                return ;
        }

        private void button1_Click(object sender, EventArgs e1)
        {
            double[] data = new double[6];
            int a =0;
            TextBox textBox;
            foreach (Control control in groupBox1.Controls)
            {
                if(control.GetType().ToString()== "System.Windows.Forms.TextBox")
                {
                    textBox = (TextBox)control;
                    data[a] = Convert.ToDouble(textBox.Text);
                    a++;
                }
            }
            try
            {
                ///用户注册
                MOD.User user = new MOD.User(UserName_box.Text, Key1_box.Text, Number_box.Text, where_box.Text);
                DAL.UserDB userDB = new DAL.UserDB();
                if (userDB.SelectUser(user.UserName) != null)
                {
                    MessageBox.Show("该用户已存在！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (Key1_box.Text != Key2.Text)
                {
                    MessageBox.Show("两次输入密码不一致！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (data[0] > data[1] || data[2] > data[3] || data[4]>data[5])
                {
                    MessageBox.Show("土壤数据范围逻辑错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (userDB.AddUser(user) != 0)
                {
                    ///预警数据设置
                    for (int i= 0; i < 6; i++)
                    {
                        MOD.Data.Data_Soil[i] = data[i];
                    }
                    DAL.SoilDataDB soilDataDB = new DAL.SoilDataDB();
                    soilDataDB.add(new MOD.Soil(data, textBox1.Text),UserName_box.Text);
                    MessageBox.Show("注册成功！", "提示", MessageBoxButtons.OK);
                    this.Close();
                }
                //添加SoilData
                
            }
            catch(Exception e)
            {
                MessageBox.Show("注册失败！"+e.ToString());    
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(op.FileName);
            }
            textBox1.Text = op.FileName;
        }
    }
}
