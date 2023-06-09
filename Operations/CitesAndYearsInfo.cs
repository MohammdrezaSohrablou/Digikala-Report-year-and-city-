using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace finaldigikala.Operations.CitesAndYearsInfo
{
    class CitesAndYearsInfo
    {
        public void CityReport(string address)
        {
            var citySet = new HashSet<string>();
            var lines = File.ReadAllLines(address);

            foreach (var line in lines)
            {
                string[] fields = line.Split(',');

                string cityName = Regex.Replace(fields[5], @"(\d|\.|,|:|-| )+", "");
                citySet.Add(cityName);
            }

            foreach (string city in citySet)
            {
                string outputDirectory = Path.Combine(@"D:\", city);
                if (Directory.Exists(outputDirectory))
                {
                    Directory.Delete(outputDirectory, true);
                }
                Directory.CreateDirectory(outputDirectory);

                string outputFile = Path.Combine(outputDirectory, "orders.csv");

                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    writer.WriteLine("ID_Order,ID_Customer,ID_Item,DateTime_CartFinalize,Amount_Gross_Order,city_name_fa,Quantity_item");

                    foreach (var line in lines)
                    {
                        string[] fields = line.Split(',');
                        string cityName = Regex.Replace(fields[5], @"(\d|\.|,|:|-| )+", "");

                        if (cityName == city)
                        {
                            writer.WriteLine($"{fields[0]},{fields[1]},{fields[2]},{fields[3]},{fields[4]},{fields[5]},{fields[6]}");
                        }
                    }
                }
            }
        }



        public void YearsReport(string address)
        {
            var yearSet = new HashSet<string>();
            var lines = File.ReadAllLines(address);

            foreach (var line in lines)
            {
                string[] fields = line.Split(',');
                string date = Regex.Replace(fields[3], @"(\d{4}\-)+", "");
                yearSet.Add(date);
            }

            foreach (string year in yearSet)
            {
                var outputDirectory = Path.Combine(@"D:\", year);
                if (Directory.Exists(outputDirectory))
                {
                    Directory.Delete(outputDirectory, true);
                }
                Directory.CreateDirectory(outputDirectory);

                string outputFile = Path.Combine(outputDirectory, "orders.csv");

                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    writer.WriteLine("ID_Order,ID_Customer,ID_Item,DateTime_CartFinalize,Amount_Gross_Order,city_name_fa,Quantity_item");

                    foreach (var line in lines)
                    {
                        string[] fields = line.Split(',');
                        string date = Regex.Replace(fields[3], @"(\d{4}\-)+", "");

                        if (date == year)
                        {
                            writer.WriteLine($"{fields[0]},{fields[1]},{fields[2]},{fields[3]},{fields[4]},{fields[5]},{fields[6]}");
                        }
                    }
                }
            }
        }
    }
}
