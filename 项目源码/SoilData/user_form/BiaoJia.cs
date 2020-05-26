using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using SoilData.MOD;
using SoilData.DAL;
using HtmlAgilityPack;

namespace SoilData.user_form
{
    public partial class BiaoJia : Form
    {
        public BiaoJia()
        {
            InitializeComponent();
        }

        private void BiaoJia_Load(object sender, EventArgs e)
        {
            SFcomboBox1.Items.Clear();
            SFcomboBox2.Items.Clear();
            comboBox4.Items.Clear();
            comboBox1.Items.Clear();
            Button.CheckForIllegalCrossThreadCalls = false;
            //加载蔬菜名
            //加载省份
            Price_SysDB price_SysDB = new Price_SysDB();
            SFcomboBox1.Items.AddRange(price_SysDB.getShengFen(1));
            SFcomboBox1.SelectedIndex = 0;
            SFcomboBox2.Items.AddRange(price_SysDB.getShengFen(2));
            SFcomboBox2.SelectedIndex = 0;
            Price_UserDB price_UserDB = new Price_UserDB();
            comboBox4.Items.AddRange(price_UserDB.SelectVeg(Data.User.ID1));
            comboBox1.Items.AddRange(price_SysDB.getName(SFcomboBox1.Text));
            comboBox1.SelectedIndex = 0;
            label9.Text = Convert.ToString(price_SysDB.select_price(SFcomboBox1.Text, comboBox1.Text));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "更新中...";
            button1.Enabled = false;
            Thread threadStart = new Thread(star);
            threadStart.Start();


        }
        private void star()
        {
            ///数据更新

            ///删除省份
            GetData getData = new GetData();
            try
            {
                getData.getPrice(SFcomboBox2.Text);
                ///添加数据
            }
            catch (Exception e)
            {
                MessageBox.Show("更新失败！请稍后再试！"+e.Message,"提示",MessageBoxButtons.OK);
                Data.WriteLog(e.Message.ToString(), 1);
                Thread.Sleep(10000);
                button1.Text = "稍等";
            }
            button1.Text = "更新";
            button1.Enabled = true;
        }
        
        /// <summary>
        /// 添加用户蔬菜价格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Price_UserDB price_UserDB = new Price_UserDB();
            Price_User price_User = new Price_User(comboBox4.Text,Convert.ToDouble(textBox1.Text),Data.User.ID1);
            if (comboBox4.SelectedIndex == -1)
                price_UserDB.add(price_User);
            else
                price_UserDB.Change(price_User);

            MessageBox.Show("标价成功!","提示",MessageBoxButtons.OK);
        }

        private void SFcomboBox1_TextChanged(object sender, EventArgs e)
        {
            Price_SysDB price_SysDB = new Price_SysDB();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange( price_SysDB.getName(SFcomboBox1.Text));
            comboBox1.SelectedIndex = 0;

            label9.Text =Convert.ToString( price_SysDB.select_price(SFcomboBox1.Text,comboBox1.Text));
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Price_SysDB price_SysDB = new Price_SysDB();
            label9.Text = Convert.ToString(price_SysDB.select_price(SFcomboBox1.Text, comboBox1.Text));
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            if(comboBox4.SelectedIndex != -1)
            {
                Price_UserDB price_User = new Price_UserDB();
                textBox1.Text =  price_User.SelectPrice(comboBox4.Text,Data.User.ID1).ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BiaoJia_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Price_UserDB price_UserDB = new Price_UserDB();
            int a = price_UserDB.delete(comboBox4.Text ,Data.User.ID1);
            if(a ==1)
            {
                MessageBox.Show("删除成功!","提示",MessageBoxButtons.OK);
                BiaoJia_Load(sender, e);
                comboBox4.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("删除失败!","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
