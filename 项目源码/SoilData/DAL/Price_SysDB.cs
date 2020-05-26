using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SoilData.MOD;

namespace SoilData.DAL
{
    /// <summary>
    /// 添加 对象 -> Price_Sys
    /// 清空 
    /// 查询(省份，名称)-> 价格
    /// </summary>
    class Price_SysDB
    {
        MySqlConnection mySqlConnection = new MySqlConnection(Data.ConStr);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="shengfen"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public int add(string shengfen,Dictionary<string,double> price)
        {
            mySqlConnection.Open();
            int a = 0;
            string sql = "insert into price_Sys (shengfen,VegName,Price) values (@shengfen,@Vegname,@price)";
            
            foreach (var value1 in price)
            {
                MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                mySqlCommand.Parameters.AddRange(
                new MySqlParameter[]
                {
                    new MySqlParameter("@shengfen",shengfen),
                    new MySqlParameter("@Vegname",value1.Key),
                    new MySqlParameter("@price",value1.Value)
                });
                a += mySqlCommand.ExecuteNonQuery();
                Console.WriteLine(value1.Key+"----"+value1.Value);
            }
            
            mySqlConnection.Close();
            return a;
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        /// <returns></returns>
        public int clear(string str)
        {
            mySqlConnection.Open();
            string sql = "delete from price_sys"+str;
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
            int a = mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return a;
        }

        /// <summary>
        /// 更新某省份数据
        /// </summary>
        /// <param name="shengfen"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public int Update(string shengfen, Dictionary<string, double> price)
        {
            clear(" where shengfen='"+shengfen+"'");
            int a = add(shengfen,price);
            return a;
        }
        /// <summary>
        /// 查询价格
        /// </summary>
        /// <param name="shengfen">省份</param>
        /// <param name="name">蔬菜名</param>
        /// <returns></returns>
        public double select_price(string shengfen,string name)
        {
            mySqlConnection.Open();
            double a = -1;
            string sql = "select price from price_sys where shengfen=@shengfen and VegName = @name";
            MySqlCommand mySqlCommand = new MySqlCommand(sql ,mySqlConnection);
            mySqlCommand.Parameters.AddRange(
                new MySqlParameter[]{
                    new MySqlParameter("@shengfen",shengfen),
                    new MySqlParameter("@name",name)
                });
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                a = Convert.ToDouble( reader[0].ToString());
                reader.Close();
            }
            mySqlConnection.Close();
            return a;
            
        }
        /// <summary>
        /// 获取所有省份和蔬菜名
        /// </summary>
        /// <returns></returns>
        public string[] getShengFen(int a )
        {
            mySqlConnection.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "select distinct shengfen from ";
            switch (a)
            {
                case 1: com.CommandText += "price_sys";break;
                case 2: com.CommandText += "sys_url";break;
            }
            com.Connection = mySqlConnection;
            List<string> list = new List<string>();
            MySqlDataReader reader = com.ExecuteReader();
            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(reader[0].ToString());
                }
            }
            mySqlConnection.Close();
            string[] line = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                line[i] = list[i];
            }
            return line;
        }
        public string[] getName(string sheng)
        {
            return get("VegName",sheng);
        }
        public string[] get(string a,string sheng)
        {
            mySqlConnection.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "select "+a+" from price_sys where shengfen='"+sheng+"'";
            com.Connection = mySqlConnection;
            List<string> list = new List<string>();
            MySqlDataReader reader = com.ExecuteReader();
            if ( reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(reader[0].ToString());
                }
            }
            mySqlConnection.Close();
            string []line = new string[list.Count];
            for(int i = 0;i<list.Count;i++)
            {
                line[i] = list[i];
            }
            return line;
        }
    }
}
