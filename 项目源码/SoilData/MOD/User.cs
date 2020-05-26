
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoilData.MOD
{
    public class User
    {
        private int ID;
        private string userName;
        private string key;
        private string number;
        private string where;

        public string UserName { get => userName; set => userName = value; }
        public string Key { get => key; set => key = value; }
        public string Number { get => number; set => number = value; }
        public string Where { get => where; set => where = value; }
        public int ID1 { get => ID; set => ID = value; }

        public User() { }
        public User(int ID,string userName, string key, string number, string where)
        {
            this.ID1 = ID;
            this.UserName = userName;
            this.Key = key;
            this.Number = number;
            this.Where = where;
        }
        public User( string userName, string key, string number, string where)
        {   
            this.UserName = userName;
            this.Key = key;
            this.Number = number;
            this.Where = where;
        }
    }
    
}
