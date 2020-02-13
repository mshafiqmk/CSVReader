using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"D:\dev\Sacramentorealestatetransactions.csv";
            var values = File.ReadAllLines(filePath)
                                   .Skip(1)
                                   .Select(v => DataFile.FromCSV(v))
                                   .ToList();
        }
        public class DataFile
        {
            //street,city,zip,state,beds,baths,sq__ft,type,sale_date,price,latitude,longitude
            public string street { get; set; }
            public string city { get; set; }
            public string zip { get; set; }
            public string beds { get; set; }
            public string sq__ft { get; set; }
            public string type { get; set; }
            public string sale_data { get; set; }
            public string beds_price { get; set; }
            public static DataFile FromCSV(string dataAsString)
            {
                var data = dataAsString.Split(',');
                var dataFile = new DataFile()
                {
                    street  = data[1],
                    city    = data[2],
                    zip     = data[3]
                };
                return dataFile;
            }
            public static void ToJson(string path , List<DataFile> values)
            {
                var json = JsonConvert.SerializeObject(values);
                File.WriteAllText(path,json);
            }
        }
    }
}