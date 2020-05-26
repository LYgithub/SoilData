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

namespace SoilData
{
    public partial class ZhongZhi : Form
    {
        public ZhongZhi()
        {
            InitializeComponent();
        }

        private void ZhongZhi_Load(object sender, EventArgs e)
        {
            SoilDataDB soilDataDB = new SoilDataDB();
            comboBox1.Items.AddRange( soilDataDB.selectCity());
            comboBox1.SelectedIndex = 0;
            textBox1.Text = soilDataDB.getEnviron(comboBox1.Text);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            SoilDataDB soilDataDB = new SoilDataDB();
            textBox1.Text = soilDataDB.getEnviron(comboBox1.Text);
        }
    }
}
