using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SoilData.MOD
{
    static class Data
    {
        private static bool login_1;
        private static User user = new User();
        private static string file;
        //server=rm-bp1h6041ox7x7d2k4to.mysql.rds.aliyuncs.com;user id = root; persistsecurityinfo=True;database=soildata
        private static string conStr = "server=rm-bp1h6041ox7x7d2k4to.mysql.rds.aliyuncs.com;port=3306;user=root;password=abc12345ABC+; database=soildata;";
        public static double[] Data_Soil = new double[6];
        public static string ConStr { get => conStr; set => conStr = value; }
        public static User User { get => user; set => user = value; }
        public static string File_get { get => file; set => file = value; }
        public static bool Login_1 { get => login_1; set => login_1 = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="a">0 登录 1 错误</param>
        public static void WriteLog(string log,int a)
        {
            string sFilePath = Application.StartupPath;
            switch (a)
            {
                case 0:sFilePath += @"\log.log";break;
                case 1:sFilePath += @"\error.log";break;
            }
            FileStream fs;
            StreamWriter sw;
            if (File.Exists(sFilePath))
            //验证文件是否存在，有则追加，无则创建
            {
                fs = new FileStream(sFilePath, FileMode.Append, FileAccess.Write);
            }
            else
            {
                fs = new FileStream(sFilePath, FileMode.Create, FileAccess.Write);
            }
            sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + log);
            sw.Close();
            fs.Close();
        }

        public  static void gatdata()
        {
            DAL.SoilDataDB soilDataDB = new DAL.SoilDataDB();
            Soil soil = soilDataDB.SelectSoil(Data.User.UserName);

            Data.Data_Soil = soil.Soil_data1;
            Data.File_get = soil.File;
        }
    }
}
