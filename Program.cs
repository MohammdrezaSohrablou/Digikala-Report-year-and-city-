using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        string address = @"D:\digikala report\orders.csv";
        DigiKalaReport x = new DigiKalaReport();

        Console.WriteLine("processing...");
        Console.WriteLine("please wait, don't close -cmd-'");
        x.CityReport(address);
        x.YearsReport(address);
        Console.WriteLine("done !");
    }
}

class DigiKalaReport
{
    public void CityReport(string address)
    {
        List<string> citys = new List<string>();
        
        using (StreamReader srreader = new StreamReader(address))
        {
            while (!srreader.EndOfStream)
            {
                string line = srreader.ReadLine();
                
                string[] fields = line.Split(',');
                
                string cityName = Regex.Replace(fields[5], @"(\d|\.|,|:|-| )+", "");
                
                citys.Add(cityName);
            }
        }

        var nonduplicatecitys = citys.Distinct();

        
        foreach (string city in nonduplicatecitys)
        {
            
            string addressOutput = @"D:\digikala report\City\orders.csv";
            using (StreamWriter strwriter = new StreamWriter(addressOutput + city + ".csv"))
            {
                
                strwriter.WriteLine("ID_Order,ID_Customer,ID_Item,DateTime_CartFinalize,Amount_Gross_Order,city_name_fa,Quantity_item");

                
                using (StreamReader srreader = new StreamReader(address))
                {
                    while (!srreader.EndOfStream)
                    {
                        string line = srreader.ReadLine();
                        
                        string[] fields = line.Split(',');
                        
                        string cityName = Regex.Replace(fields[5], @"(\d|\.|,|:|-| )+", "");
                        
                        if (cityName == city)
                        {
                            
                            strwriter.WriteLine($"{fields[0]},{fields[1]},{fields[2]},{fields[3]},{fields[4]},{fields[5]},{fields[6]}");
                        }
                    }
                }
            }
        }
    }





    public void YearsReport(string address)
    {
        List<string> years = new List<string>();
        
        using (StreamReader srreader = new StreamReader(address))
        {
            while (!srreader.EndOfStream)
            {
                string line = srreader.ReadLine();
               
                string[] fields = line.Split(',');
                
                string date = Regex.Replace(fields[3], @"(\d{4}\-)+", "");
                
                years.Add(date);
            }
        }

        var nonduplicateyears = years.Distinct();

        
        foreach (string dateyear in nonduplicateyears)
        {
            
            string addressOutput = @"D:\digikala report\Years\orders.csv";
            using (StreamWriter strwriter = new StreamWriter(addressOutput + dateyear + ".csv"))
            {
                
                strwriter.WriteLine("ID_Order,ID_Customer,ID_Item,DateTime_CartFinalize,Amount_Gross_Order,city_name_fa,Quantity_item");

                
                using (StreamReader srreader = new StreamReader(address))
                {
                    while (!srreader.EndOfStream)
                    {
                        string line = srreader.ReadLine();

                        string[] fields = line.Split(',');
                        string date = Regex.Replace(fields[3], @"(\d{4}\-)+", "");
                        if (date == dateyear)
                        {
                            strwriter.WriteLine($"{fields[0]},{fields[1]},{fields[2]},{fields[3]},{fields[4]},{fields[5]},{fields[6]}");
                        }
                    }
                }
            }
        }

    }


}




















