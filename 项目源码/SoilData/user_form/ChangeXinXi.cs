using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoilData.MOD;

namespace SoilData.user_form
{
    public partial class ChangeXinXi : Form
    {
        public ChangeXinXi()
        {
            InitializeComponent();
        }

        private void ChangeXinXi_Load(object sender, EventArgs e)
        {
            UserName_box.Text = Data.User.UserName;
            UserName_box.Enabled = false;
            Number_box.Text = Data.User.Number;
            where_box.Text = Data.User.Where;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAL.UserDB userDB = new DAL.UserDB();
            int a = userDB.ChangeWhere(UserName_box.Text, where_box.Text);
            a += userDB.ChangeNumber(UserName_box.Text, Number_box.Text);
            if (a > 0)
            {
                MessageBox.Show("修改成功！","提示",MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("修改失败！", "提示", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            Data.User = userDB.SelectUser(Data.User.UserName);
            this.Close();
        }
    }
}
