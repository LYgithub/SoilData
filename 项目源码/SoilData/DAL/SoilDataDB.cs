using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SoilData.MOD;

namespace SoilData.DAL
{
    class SoilDataDB
    {
        MySqlConnection sqlcon = new MySqlConnection(Data.ConStr);

        //添加
        public int add(Soil  soil,string username)
        {
            sqlcon.Open();
            string sql = "insert into soil (UserID,WenDuMax,WenDumin,shidumax,shidumin,qiyamax,qiyamin,file) " +
                "values (@UserID,@WenDuMax,@WenDumin,@shidumax,@shidumin,@qiyamax,@qiyamin,@file)";
            MySqlCommand mySqlCommand = new MySqlCommand(sql, sqlcon);
            mySqlCommand.Parameters.AddRange(
                new MySqlParameter[]
                {
                    new MySqlParameter("@userID",username),
                    new MySqlParameter("@WenDuMax",soil.Soil_data1[1]),
                    new MySqlParameter("@WenDumin",soil.Soil_data1[0]),
                    new MySqlParameter("@shidumax",soil.Soil_data1[3]),
                    new MySqlParameter("@shidumin",soil.Soil_data1[2]),
                    new MySqlParameter("@qiyamax",soil.Soil_data1[5]),
                    new MySqlParameter("@qiyamin",soil.Soil_data1[4]),
                    new MySqlParameter("@file",soil.File),

                });
            int a = mySqlCommand.ExecuteNonQuery();
            sqlcon.Close();
            return a;
        }
        //修改
        public int xiugai(Soil soil)
        {
            sqlcon.Open();
            string sql = "update soil set WenDuMax=@WenDuMax,WenDumin=@WenDumin,shidumax=@shidumax," +
                "shidumin=@shidumin,qiyamax=@qiyamax,qiyamin=@qiyamin,file=@file where userid=@userID";
            MySqlCommand mySqlCommand = new MySqlCommand(sql, sqlcon);
            mySqlCommand.Parameters.AddRange(
                new MySqlParameter[]
                {
                    new MySqlParameter("@userID",Data.User.UserName),
                    new MySqlParameter("@WenDuMax",soil.Soil_data1[0]),
                    new MySqlParameter("@WenDumin",soil.Soil_data1[1]),
                    new MySqlParameter("@shidumax",soil.Soil_data1[2]),
                    new MySqlParameter("@shidumin",soil.Soil_data1[3]),
                    new MySqlParameter("@qiyamax",soil.Soil_data1[4]),
                    new MySqlParameter("@qiyamin",soil.Soil_data1[5]),
                    new MySqlParameter("@file",soil.File)

                });
            int a = mySqlCommand.ExecuteNonQuery();
            sqlcon.Close();
            return a;
        }
        //读取
        public MOD.Soil SelectSoil(string userName)
        {
            sqlcon.Open();
            MySqlCommand mySqlCommand = new MySqlCommand("select * from soil where UserID='" + userName + "'", sqlcon);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            if (reader.Read())
            {
                MOD.Soil soil = new MOD.Soil(reader);
                sqlcon.Clone();
                return soil;
            }
            else
            {
                sqlcon.Close();
                return null;
            }
        }

        /// <summary>
        /// 获取蔬菜名称//
        /// </summary>
        /// <returns>string数组</returns>
        public string[] selectCity()
        {
            List<string> environ = new List<string>();
            sqlcon.Open();
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.CommandText = "select VegName from environment";
            mySqlCommand.Connection = sqlcon;
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    environ.Add(reader[0].ToString());
                }
            }
            string []x = new string[environ.Count];
            for(int i = 0; i < environ.Count; i++)
            {
                x[i] = environ[i];
            }
            sqlcon.Close();
            return x;
        }
        /// <summary>
        /// 根据蔬菜名称获取生长环境
        /// </summary>
        /// <param name="name">蔬菜名称</param>
        /// <returns>环境</returns>
        public string getEnviron(string name)
        {
            string x = "";
            sqlcon.Open();
            MySqlCommand mySqlCommand = new MySqlCommand("select Environ from environment where VegName='"+name+"'", sqlcon);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            if (reader.Read())
            {
                x = reader[0].ToString();
            }
            sqlcon.Close();
            return x;
        }

    }
}
