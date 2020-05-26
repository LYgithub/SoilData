using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using HtmlAgilityPack;
using SoilData.MOD;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;

namespace SoilData
{
    public partial class Main : Form
    {
        public DataGridView dataview;
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            
            if (!Data.Login_1)
                label1.Text = "欢迎回来!";
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

            #region//加载天气
            try
            {
                HtmlWeb htmlWeb = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = htmlWeb.Load("http://i.tianqi.com/index.php?c=code&id=34&icon=1&num=2");

                ///显示所在地
                HtmlNodeCollection htmlNodes = doc.DocumentNode.SelectNodes("//a");
                toolStripStatusLabel2.Text = htmlNodes[0].InnerText.Trim();
                ///插入图片
                ////*[@id="mobile280"]/div/a[2]/span[1]/img
                htmlNodes = doc.DocumentNode.SelectNodes("//*[@id='mobile280']/div/a[2]/span[1]/img");
                string url = "http:" + htmlNodes[0].Attributes["src"].Value;
                // 图片测试
                System.Net.WebRequest webreq = System.Net.WebRequest.Create(url);
                System.Net.WebResponse webres = webreq.GetResponse();
                using (System.IO.Stream stream = webres.GetResponseStream())
                {
                    toolStripStatusLabel3.Image = Image.FromStream(stream);
                }

                ///获取天气情况
                htmlNodes = doc.DocumentNode.SelectNodes("//span");
                String tianqi = "|温度：";
                foreach (var iteam in htmlNodes)
                {
                    tianqi += iteam.InnerText.Trim();
                }
                doc = htmlWeb.Load("http://www.tianqi.com/");
                htmlNodes = doc.DocumentNode.SelectNodes("//p[@class='p_2']");
                tianqi += "|" + htmlNodes[0].InnerText;

                htmlNodes = doc.DocumentNode.SelectNodes("//p[@class='p_3']");
                tianqi +="|" + htmlNodes[0].InnerText ;

                htmlNodes = doc.DocumentNode.SelectNodes("//p[@class='p_1']");
                tianqi = htmlNodes[0].InnerText + tianqi;
                

                toolStripStatusLabel4.Text = tianqi + "|";
            }
            catch (Exception e1)
            {
                MessageBox.Show("天气加载失败！", "提示");
                Data.WriteLog("天气加载失败！"+e1.Message.ToString(), 1);
                statusStrip1.Hide();
            }

            #endregion
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.WriteLog(Data.User.UserName+" 退出！",0);
            Application.Exit();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about about_form = new about();
            about_form.Show();
        }

        private void 图形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Hide();
            groupBox2.Show();
            groupBox1.Hide();
            groupBox2.Location = new Point(35, 73);
            try
            {

                ///加载数据
                string[] a = getTime();
                comboBox2.Items.AddRange(a);
                leixing.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                data_load();
            }catch(Exception e1)
            {
                MessageBox.Show("请确保数据文件路径的正确性！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Data.WriteLog(e1.Message, 1);
            }
        }

        private void data_load()
        {
            try
            {
                #region//折线图的绘制
                StreamReader sr = new StreamReader(Data.File_get, Encoding.UTF8);
                string txt = sr.ReadToEnd().Replace("\n", "_");
                string[] nodes = txt.Split('_');

                //加载数据
                chart1.Series.Clear();
                Series series = new Series("数据");
                series.ChartType = SeriesChartType.Spline;
                //SeriesChartType.Spline;
                series.BorderWidth = 2;
                series.ShadowOffset = 1;
                series.Color = Color.Blue;
                series.IsValueShownAsLabel = true;
                series.BorderColor = Color.Blue;
                //添加标记
                series.MarkerStyle = MarkerStyle.Circle;
                series.MarkerSize = 8;
                series.XValueType = ChartValueType.DateTime;

                //chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.Red;
                //添加坐标轴注释

                chart1.ChartAreas[0].AxisX.Title = "时间";
                chart1.ChartAreas[0].AxisY.Title = "数据/";

                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";

                switch (leixing.SelectedIndex)
                {
                    case 0:
                        chart1.ChartAreas[0].AxisY.Title += "℃"; break;
                    case 1:
                        chart1.ChartAreas[0].AxisY.Title += "%"; break;
                    case 2:
                        chart1.ChartAreas[0].AxisY.Title += "kPa"; break;
                }
                //温度湿度气压最值
                double Soil_Max = Data.Data_Soil[2 * leixing.SelectedIndex];//Wendu 0 shidu 2 qiya 4  2* leixing.selectedIndex
                double Soil_Min = Data.Data_Soil[2 * leixing.SelectedIndex + 1];//1 3 5     2*leixing.selectindex+1;
                                                                                //
                Series series2 = new Series("预警下限/" + Soil_Min);
                series2.ChartType = SeriesChartType.Line;
                series2.Color = Color.Red;
                series2.BorderWidth = 1;

                Series series4 = new Series("预警上限/" + Soil_Max);
                series4.ChartType = SeriesChartType.Line;
                series4.Color = Color.Red;
                series4.BorderWidth = 1;
                //添加警戒线
                double Max = 0;
                double Min = 0;
                foreach (string node in nodes)
                {
                    string[] strs = node.Split(' ');
                    if (strs[0] != "" && strs[0] == comboBox2.Text)
                    {
                        double data = Convert.ToDouble(strs[2 + leixing.SelectedIndex].Replace("%", "").Replace("kPa", "").Replace("℃", "").Replace("KPa", ""));
                        string time = strs[1];

                        Max = Max > data ? Max : data;
                        Min = Min < data ? Min : data;
                        int count = series.Points.AddXY(DateTime.Parse(time).ToOADate(), data);
                        if (data > Soil_Max || data < Soil_Min)
                        {
                            series.Points[count].MarkerColor = Color.Red;
                        }

                        series2.Points.AddXY(DateTime.Parse(time), Soil_Min);//min
                        series4.Points.AddXY(DateTime.Parse(time), Soil_Max);//max
                    }
                }
                Max = Max > Soil_Max ? Max : Soil_Max;
                Min = Min < Soil_Min ? Min : Soil_Min;
                chart1.ChartAreas[0].AxisY.Maximum = Max + 10;
                chart1.ChartAreas[0].AxisY.Minimum = Min - 10;
                chart1.Series.Add(series);
                chart1.Series.Add(series2);//预警上限
                chart1.Series.Add(series4);//预警下限
                chart1.Width = 880;
                chart1.Height = 500;
                #endregion
            }
            catch(Exception e)
            {
                Data.WriteLog(e.Message, 1);
            }

        }

        private void 基础设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user_form.SheZhi sheZhi = new user_form.SheZhi();
            sheZhi.Show();
        }

        private void 表格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Hide();
            groupBox2.Hide();
            groupBox1.Show();

            ///加载数据
            try
            {
                string[] a = getTime();
                comboBox1.Items.AddRange(a);
                leixing.SelectedIndex = 0;
                comboBox1.SelectedIndex = 0;
                groupBox1.Location = new Point(35, 73);
                comboBox1.SelectedIndex = 0;
                getTable();
            }
            catch(Exception e1)
            {
                MessageBox.Show("请确保数据文件路径的正确性！","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Data.WriteLog(e1.Message.ToString(),1);
            }

            
        }

        private void 标价ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            user_form.BiaoJia biaoJia = new user_form.BiaoJia();
            biaoJia.Show();
            this.Cursor = Cursors.Default;
        }

        private void 种植ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZhongZhi zhongZhi = new ZhongZhi();
            zhongZhi.Show();
        }


        private string[] getTime()
        {
            StreamReader myStreamReader;
            List<string> timelist = new List<string>();
            try
            {
                string tline;
                myStreamReader = new StreamReader(Data.File_get, Encoding.UTF8);
                int a = myStreamReader.ReadToEnd().Split('\n').Length;
                Console.WriteLine(a);

                string[,] x = new string[a, 5];
                myStreamReader = new StreamReader(Data.File_get, Encoding.UTF8);
                string str = null;
                for (int i = 0; myStreamReader.Peek() != -1; i++)
                {
                    tline = myStreamReader.ReadLine();
                    string[] lis = tline.Split(' ');
                    if (lis[0] == "")
                        continue;
                    //返回日期
                    if (str != lis[0])
                        timelist.Add(lis[0]);
                    str = lis[0];
                    
                    for (int j = 0; j < 5; j++)
                    {
                        x[i, j] = lis[j];
                    }
                }


                myStreamReader.Close();
                string[]  time= new string[timelist.Count];
                for(int i = 0; i < timelist.Count; i++)
                {
                    time[i] = timelist[i];
                }
                return time;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Data.WriteLog(ex.Message.ToString(), 1);
                return null;
            }

        }

        private void getTable()
        {
            dataGridView1.Rows.Clear();
            StreamReader sr = new StreamReader(Data.File_get, Encoding.UTF8);
            string txt = sr.ReadToEnd().Replace("\n", "_");
            string[] nodes = txt.Split('_');
            foreach (string node in nodes)
            {
                string[] strs = node.Split(' ');
                if (strs[0] != "" && strs[0] == comboBox1.Text)
                {
                    dataGridView1.Rows.Add(strs[0], strs[1], strs[2], strs[3], strs[4]);
                    //
                    //预警数据
                    //
                    double data = Convert.ToDouble(strs[2].Replace("℃", ""));
                    if(data>Data.Data_Soil[0]||data<Data.Data_Soil[1])
                        dataGridView1.Rows[dataGridView1.RowCount-2].Cells[2].Style.ForeColor = Color.Red;

                    data = Convert.ToDouble(strs[3].Replace("%", ""));
                    if (data > Data.Data_Soil[2] || data < Data.Data_Soil[3])
                        dataGridView1.Rows[dataGridView1.RowCount - 2].Cells[3].Style.ForeColor = Color.Red;

                    data = Convert.ToDouble(strs[4].Replace("kPa", "").Replace("KPa",""));
                    if (data > Data.Data_Soil[4] || data < Data.Data_Soil[5])
                        dataGridView1.Rows[dataGridView1.RowCount - 2].Cells[4].Style.ForeColor = Color.Red;
                }
            }
            //绑定数据源 
            BindingSource bs = new BindingSource();
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            getTable();
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            data_load();
        }

        private void leixing_TextChanged(object sender, EventArgs e)
        {
            data_load();
        }
        

        private void chart1_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int i = e.HitTestResult.PointIndex;
                DataPoint dp = e.HitTestResult.Series.Points[i];
                e.Text = string.Format("时间:{0},数值:{1}",GetTime(dp.XValue), dp.YValues[0]);
            }

        }
        private string GetTime(double a)
        {
            //取小数部分
            a = a - (int)a;
            //*24
            a = a * 24;
            int H = (int)a;
            //取小数部分
            a = a - (int)a;
            //*60
            int M = (int)(a * 60);
            //a = a - M;
            a = a * 60 - M;
            int S = (int)Math.Round(a * 60);
            return H + ":" + M + ":" + S;
        }

        private void 登录日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string v_OpenFolderPath = Application.StartupPath + @"\log.log";
            System.Diagnostics.Process.Start(v_OpenFolderPath);
        }

        private void 错误日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string v_OpenFolderPath = Application.StartupPath + @"\error.log";
            System.Diagnostics.Process.Start(v_OpenFolderPath);
        }

        private void 密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DAL.UserDB userDB = new DAL.UserDB();
            ChangeKey changeKey = new ChangeKey(Data.User);
            changeKey.Show();
        }

        private void 信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user_form.ChangeXinXi changeXinXi = new user_form.ChangeXinXi();
            changeXinXi.Show();
        }
    }
}
