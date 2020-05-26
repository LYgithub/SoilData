using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoilData.DAL;
using SoilData.MOD;

namespace SoilData
{
    public partial class login : System.Windows.Forms.Form
    {
        
        public login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ZhuCe zhuce = new ZhuCe();
            zhuce.Show();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e1)
        {
            this.Cursor =Cursors.WaitCursor;
            try
            {
                string name = ID_box.Text;
                string key = key_box.Text;

                DAL.UserDB userDB = new DAL.UserDB();
                MOD.User user = userDB.SelectUser(name);
                if (user != null)
                {
                    if (user.Key == key)
                    {
                        MOD.Data.User = user;
                        Data.gatdata();
                        Data.Login_1 = true;
                        Main main = new Main();
                        main.yonghu_ToolStripMenuItem.Text = user.UserName;
                        main.Show();
                        Data.WriteLog(user.UserName+" 登录成功！",0);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误！", "提示");
                        this.Cursor = Cursors.Default;
                        Data.WriteLog(user.UserName + " 登录失败！", 0);
                    }
                        
                }
                else
                {
                    MessageBox.Show("尚未注册该用户!", "提示");
                    this.Cursor = Cursors.Default;
                }
                    
            }
            catch (Exception e)
            {
                MessageBox.Show("请确保网络畅通！", "温馨提示");
                Data.WriteLog(e.Message.ToString(),1);
                this.Cursor = Cursors.Default;
            }
        }

        

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal && this.Visible == true)

            {

                this.notifyIcon1.Visible = true;//在通知区显示Form的Icon

                this.WindowState = FormWindowState.Normal;

                this.Visible = false;

                this.ShowInTaskbar = false;//使Form不在任务栏上显示

            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Data.Login_1 = false;
                Main main = new Main();
                main.Show();
            }
            if (e.Button == MouseButtons.Right)
            {
                myMenu.Show();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.WriteLog(Data.User.UserName + " 退出！", 0);
            Application.Exit();
        }
        
    }
}
