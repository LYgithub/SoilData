using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoilData.MOD
{
    /// <summary>
    /// 用户蔬菜价格类
    /// </summary>
    public class Price_User
    {
        string name;
        double price;
        int userid;
        public Price_User() { }
        public Price_User(string name ,double price ,int id)
        {
            this.name = name;
            this.price = price;
            this.userid = id;
        }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public int Userid { get => userid; set => userid = value; }
    }
}
