using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoilData.MOD;
using MySql.Data.MySqlClient;

namespace SoilData.DAL
{
    /// <summary>
    /// 用户蔬菜价格访问层
    /// 
    /// </summary>
    public class Price_UserDB
    {
        MySqlConnection mySqlConnection = new MySqlConnection(Data.ConStr);

        public int add(Price_User price)
        {
            mySqlConnection.Open();
            string sql = "insert into price_user (VegName,Price,User) values (@name,@price,@user)";
            MySqlCommand mySqlCommand = new MySqlCommand(sql,mySqlConnection);
            mySqlCommand.Parameters.AddRange(
                new MySqlParameter[]
                {
                    new MySqlParameter("@name",price.Name),
                    new MySqlParameter("@price",price.Price),
                    new MySqlParameter("@user",price.Userid)
                });
            int a = mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return a;
        }

        public int delete(string name,int id)
        {
            try
            {
                mySqlConnection.Open();
                string sql = "delete from price_user where VegName=@name and user=@id";
                MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                mySqlCommand.Parameters.AddRange(
                    new MySqlParameter[]
                    {
                    new MySqlParameter("@name", name),
                    new MySqlParameter("id",id)
                    }

                    );
                int a = mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                return a;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public int Change(Price_User price)
        {
            mySqlConnection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.CommandText = "update price_user set price=@price where VegName=@name and user=@id";
            mySqlCommand.Connection = mySqlConnection;
            mySqlCommand.Parameters.AddRange(
                new MySqlParameter[]{
                    new MySqlParameter("@price",price.Price),
                    new MySqlParameter("@name",price.Name),
                    new MySqlParameter("@id",price.Userid)
                });
            int a = mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return a;
        }
        public double SelectPrice(string name ,int id)
        {
            double a = -1;
            mySqlConnection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.CommandText = "select price from price_user where VegName=@name and user=@id";
            mySqlCommand.Connection = mySqlConnection;
            mySqlCommand.Parameters.AddRange(
                new MySqlParameter[]
                {
                    new MySqlParameter("@name",name),
                    new MySqlParameter("@id",id)
                }
                );
            MySqlDataReader read = mySqlCommand.ExecuteReader();
            if (read.HasRows)
            {
                read.Read();
                a = Convert.ToDouble(read[0].ToString());
            }

            mySqlConnection.Close();
            return a;
        }
        public string[] SelectVeg(int id)
        {
            List<string> list = new List<string>();
            mySqlConnection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.CommandText = "select VegName from price_user where user=@id";
            mySqlCommand.Connection = mySqlConnection;
            mySqlCommand.Parameters.AddRange(
                new MySqlParameter[]
                {
                    new MySqlParameter("@id",id)
                }
                );
            MySqlDataReader read = mySqlCommand.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    list.Add(read[0].ToString());
                }
               
            }
            string[] line = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                line[i] = list[i];
            }
            mySqlConnection.Close();
            return line;
        }
    }
}
