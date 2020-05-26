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
    public partial class ChangeKey : Form
    {
        private MOD.User user;
        public ChangeKey(MOD.User user)
        {
            InitializeComponent();
            this.user = user;

            TextBox textBox;
            foreach (Control control in this.Controls)
            {
                if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    textBox = (TextBox)control;
                    if (control.Name == "Old_Key")
                        textBox.GotFocus += box_GotFocus;
                    else
                        textBox.GotFocus += box_GotFocus1;

                }
            }
        }
        private void box_GotFocus(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = null;
        }
        private void box_GotFocus1(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = null;
            textBox.PasswordChar = '*';
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e1)
        {
            //Console.WriteLine(user);
            if(Old_Key.Text != user.Key)
            {
                MessageBox.Show("旧密码错误！","⚠警告", MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
            }
            else if(New_Key.Text != Right_Key.Text)
            {
                MessageBox.Show("输入密码不一致！","⚠警告",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    DAL.UserDB userDB = new DAL.UserDB();
                    userDB.ChangeKey(user.UserName, New_Key.Text);
                    MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK);
                    this.Close();
                }
                catch(Exception e)
                {
                    MessageBox.Show("发生未知错误！"+e.ToString(), "⚠警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    MOD.Data.WriteLog("密码修改失败！"+e.Message.ToString(),1);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
