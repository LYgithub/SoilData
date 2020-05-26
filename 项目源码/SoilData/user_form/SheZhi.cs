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
    public partial class SheZhi : Form
    {
        public SheZhi()
        {
            InitializeComponent();
        }

        private void box_GotFocus(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] data = new double[6];
            TextBox textBox;
            int i = 0;
            foreach (Control control in groupBox1.Controls)
            {
                if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    textBox = (TextBox)control;
                    data[i++] = Convert.ToDouble(textBox.Text.ToString());
                }
            }
            if (data[0] < data[1] || data[2] < data[3] || data[4] < data[5]) 
            {
                MessageBox.Show("土壤数据范围逻辑错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                ///预警数据设置
                for (i = 0; i < 6; i++)
                {
                    MOD.Data.Data_Soil[i] = data[i];
                }
                DAL.SoilDataDB soilDataDB = new DAL.SoilDataDB();
                soilDataDB.xiugai(new Soil( data,textBox1.Text));
                MessageBox.Show("设置成功！", "提示", MessageBoxButtons.OK);
                Data.gatdata();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(op.FileName);
                Data.File_get = op.FileName;
            }
            textBox1.Text = op.FileName;
        }

        private void SheZhi_Load(object sender, EventArgs e)
        {
            TextBox textBox;
            int i = 0;
            foreach (Control control in groupBox1.Controls)
            {
                if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    textBox = (TextBox)control;
                    textBox.Text = MOD.Data.Data_Soil[i++].ToString();

                    textBox.GotFocus += box_GotFocus;
                }
            }
            textBox1.Text = Data.File_get;

        }
    }
}
