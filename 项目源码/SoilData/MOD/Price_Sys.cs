using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoilData.MOD
{
    /// <summary>
    /// 爬取的蔬菜价格类
    /// </summary>
    public class Price_Sys
    {
        string shengfen;
        string name;
        double price;

        public string Shengfen { get => shengfen; set => shengfen = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
      
    }
}
