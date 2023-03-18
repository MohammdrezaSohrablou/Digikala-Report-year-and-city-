using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using finaldigikala.Model;

namespace finaldigikala.DigikalaOperations
{
    internal class DigikalaOperations
    {
        List<GetData> Digikaladata;

        public DigikalaOperations(List<GetData> Digikaladata)
        {
            this.Digikaladata = Digikaladata;
        }
        public IEnumerable<GetData> CustomerSearch(int Cid)
        {
            return Digikaladata
                .Where(x => x.CustomerId == Cid);
        }
        public string OrderSearch(int Oid)
        {
            return Digikaladata
                .Where(x => x.ItemId == Oid).Select(x => x.OrderDateTime).ToString();
        }
        public List<GetData> ItemSearch(int Iid)
        {
            return Digikaladata
                .Where(X => X.ItemId == Iid).ToList();
        }

        public List<int> AllSalesByCities(string city)
        {
            return Digikaladata.Where(x => x.cityname == city).Select(x => x.GrossAmount).ToList();
        }
        public long SumSalesByCities(string city)
        {
            List<int> sales = AllSalesByCities(city);
            long total = 0;

            foreach (int sale in sales)
            {
                total += sale;
            }

            return total;
        }
        //public Dictionary<bool, int> GetSalesByCity(string city)
        //{
        //    return Digikaladata.GroupBy(x => x.cityname == city).ToDictionary(y => y.Key, y => y.Sum(x => x.GrossAmount));
        //}

        
        private List<int> AllSalesByYear(int year)
        {
            return Digikaladata.
             Where(x => x.OrderDateTime.Year == year).Select(x => x.GrossAmount).ToList();
        }
        public long SumSalesByYear(int year)
        {
            List<int> sales = AllSalesByYear(year);
            long total = 0;

            foreach (int sale in sales)
            {
                total += sale;
            }

            return total;

        }

        private List<int> AllSalesByItem(int year)
        {
            return Digikaladata.
             Where(x => x.ItemId == year).Select(x => x.GrossAmount).ToList();
        }
        public long SumSalesByItem(int Iid)
        {
            List<int> sales = AllSalesByItem(Iid);
            long total = 0;

            foreach (int sale in sales)
            {
                total += sale;
            }

            return total;

        }

    }
}
