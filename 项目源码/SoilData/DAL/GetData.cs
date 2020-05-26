using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using SoilData.DAL;
using SoilData.MOD;
using MySql.Data.MySqlClient;


namespace SoilData.DAL
{
    class GetData
    {
        HtmlWeb webClinent;
        HtmlDocument doc;
        HtmlNodeCollection titleNodes;
        public GetData()
        {
            webClinent = new HtmlWeb();
        }



        /// <summary>
        /// 根据省份读取数据库，获取省份的Url
        /// </summary>
        /// <param name="name">省份</param>
        /// <returns></returns>
        public string getUrl(string name)
        {
            MySqlConnection mysqlcon = new MySqlConnection(Data.ConStr);
            mysqlcon.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select Url from Sys_Url where shengfen=@shengfen";
            cmd.Connection = mysqlcon;
            cmd.Parameters.Add(
                new MySqlParameter("@shengfen",name)
                );
            MySqlDataReader read = cmd.ExecuteReader();
            read.Read();
            return read[0].ToString();
                 
            
        }


        #region

        /// <summary>
        /// 获取全部省份的Url
        /// href="/price/2019/all/m2d-1cta1357by-1.html"
        /// http://www.vipveg.com/price/2019/all/m2d-1cta1357by-1.html
        /// </summary>
        //public Dictionary<string, string> getUrl()
        //{

        //    Dictionary<string, string> list_url = new Dictionary<string, string>() ;
        //    doc = webClinent.Load("http://www.vipveg.com/price/2019/all/m2d-1cta1357by-1.html");
        //    titleNodes = doc.DocumentNode.SelectNodes("//div/table[6]/tr/td[2]/table[1]/tr[2]/td/table/tr[4]/td[2]/a");
        //    if (titleNodes != null)
        //    {
        //        foreach (var iteam in titleNodes)
        //        {
        //            list_url.Add(iteam.InnerText, "http://www.vipveg.com" + iteam.Attributes["href"].Value.ToString());
        //            Console.WriteLine("'"+iteam.InnerText+"','"+"http://www.vipveg.com" + iteam.Attributes["href"].Value.ToString()+"'");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("nothing！");
        //    }
        //    if (list_url.ContainsKey("全部"))
        //        list_url.Remove("全部");
        //    return list_url;
        //}

        #endregion

        public void  getPrice(string name)
        {
            try
            {
                Price_SysDB price_SysDB = new Price_SysDB();
                string url = getUrl(name);
                price_SysDB.Update(name, JiLu(url));
                Thread.Sleep(10000);
            }
            catch(Exception e)
            {
                Data.WriteLog(e.Message.ToString(), 1);
            }
            
        }


        /// <summary>
        /// 获取20 页的蔬菜价格数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Dictionary<string ,double > JiLu(string url)
        {

            string url1;
            Dictionary<string, double> list_price = new Dictionary<string, double>();
            try
            {
                for (int x = 1; x < 21; x++)
                {
                    url1 = url.Replace(".html", "p" + x + ".html");
                    doc = webClinent.Load(url1);
                    titleNodes = doc.DocumentNode.SelectNodes("//div/table[6]/tr/td[2]/table[2]/tr[2]/td/table/tr[2]/td/table/tr");
                    int j = -1;
                    Price_Sys price = new Price_Sys();
                    for (int i = 0; titleNodes != null && i < titleNodes.Count; i++)
                    {
                        price.Name = titleNodes[i].SelectNodes("td")[0].InnerText;
                        string price_str = titleNodes[i].SelectNodes("td")[4].InnerText.Remove(0, 1);
                        price.Price = Convert.ToDouble(price_str);

                        for (; i < titleNodes.Count - 1 && price.Name == titleNodes[i + 1].SelectNodes("td")[0].InnerText; i++)
                        {
                            price.Price += Convert.ToDouble(titleNodes[i + 1].SelectNodes("td")[4].InnerText.Remove(0, 1));
                        }
                        price.Price = price.Price / (i - j);
                        if (list_price.ContainsKey(price.Name))
                        {
                            list_price[price.Name] = (list_price[price.Name] + price.Price) / 2;
                        }
                        else
                        {
                            list_price.Add(price.Name, price.Price);
                        }
                        j = i;
                    }
                }
                return list_price;
            }
            catch (Exception e)
            {

                Data.WriteLog(e.Message + " 登录成功！", 0);
                return null;
            }
            
        }
    }
}
