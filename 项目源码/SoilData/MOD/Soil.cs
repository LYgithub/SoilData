using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoilData.MOD
{
    public class Soil
    {
        private double []Soil_data;
        private string file;
        public Soil() { }
        public Soil(MySqlDataReader reader)
        {
            Soil_data = new double[6];
            for(int i = 0; i < 6; i++)
            {
                Soil_data[i] = Convert.ToDouble(reader[i+2].ToString());
            }
            file = reader[8].ToString();
        }
        public Soil(double []soil,string file)
        {
            Soil_data = soil;
            this.file = file;
        }
        
        public string File { get => file; set => file = value; }
        public double[] Soil_data1 { get => Soil_data; set => Soil_data = value; }
        

    }
}
