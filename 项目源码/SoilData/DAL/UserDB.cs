using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; 

namespace SoilData.DAL
{
    /// <summary>
    /// 数据访问层
    /// 用户层的增删改查
    /// </summary>
    public class UserDB
    {
        private MySqlConnection sqlConnection = new MySqlConnection(MOD.Data.ConStr);
        public UserDB()
        {
            //sqlConnection.Open();
        }
        ~UserDB()
        {
            //sqlConnection.Close();
        }
        //增加
        public int AddUser(MOD.User user)
        {
            sqlConnection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = sqlConnection;
            mySqlCommand.CommandText = "insert into User (UserName ,UserKey,UserNumber,UserWhere) " +
                "values (@UserName ,@Key ,@Number,@Where)";
            mySqlCommand.Parameters.AddRange(
                new MySqlParameter[]
                {
                    new MySqlParameter ("@UserName",user.UserName),
                    new MySqlParameter("@Key",user.Key),
                    new MySqlParameter("@Number",user.Number),
                    new MySqlParameter("@Where",user.Where)
                }
            );
            int a =  mySqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return a;
        }
        //查询
        public MOD.User SelectUser(string userName)
        {
            sqlConnection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand("select * from user where UserName='" + userName + "'", sqlConnection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            if (reader.Read())
            {
                MOD.User user = new MOD.User(Convert.ToInt32(reader[0].ToString()),reader[1].ToString(), reader[2].ToString(),
                    reader[3].ToString(), reader[4].ToString());
                sqlConnection.Clone();
                return user;
            }
            else
            {
                sqlConnection.Close();
                return null;
            }
        }
        //删除
        public int deleteuser(string username)
        {
            sqlConnection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand("delete from user where username='" + username + "'", sqlConnection);
            int a = mySqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return a;
        }
        //修改电话
        public int ChangeNumber(string userName ,string Number)
        {
            string sql = "update user set UserNumber='" + Number + "' " +
                "where userName='" + userName+"'";
            return xiugaiuser(sql);
        }
        //修改密码
        public int ChangeKey(string userName,string Key)
        {
            string sql = "update user set Userkey='" + Key + "' " +
                "where userName='" + userName + "'";
            return xiugaiuser(sql);

        }
        //修改地址
        public int ChangeWhere(string userName, string Where)
        {
            string sql = "update user set UserWhere='" + Where + "' " +
                "where userName='" + userName + "'";
            return xiugaiuser(sql);

        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Change(MOD.User user)
        {
            string sql = "update user set username='"+user.UserName+",userkey='"+user.Key+"'," +
                "userNumber='"+user.Number+"',userWhere='"+user.Where+"' where ID='"+user.ID1+"'";
            return xiugaiuser(sql);
            
        }
        public int xiugaiuser(string sql)
        {
            sqlConnection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, sqlConnection);
            int a = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return a;
        }
    }
}
