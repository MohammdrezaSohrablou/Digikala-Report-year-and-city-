using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finaldigikala.Model
{
    class GetDataContext
    {
        private GetData getdata;
        private string line;
        public List<GetData> Digikaladata { get; }
        public GetDataContext(string address)
        {
            Digikaladata = new List<GetData>();
            using StreamReader reader = new StreamReader(address);
            reader.ReadLine();
            while (!reader.EndOfStream) 
            {
                line = reader.ReadLine();
                getdata = new GetData();

                getdata.OrderId = int.Parse(line.Split(",")[0]);
                getdata.CustomerId = int.Parse(line.Split(",")[1]);
                getdata.ItemId = int.Parse(line.Split(",")[2]);
                getdata.OrderDateTime = DateTime.Parse(line.Split(",")[3]);
                getdata.GrossAmount = int.Parse(line.Split(",")[4].Replace(".0", ""));
                getdata.cityname = line.Split(",")[5];
                getdata.Quantity = int.Parse(line.Split(",")[6].Replace(".0", ""));
                Digikaladata.Add(getdata);
            }

        }
    }
}
