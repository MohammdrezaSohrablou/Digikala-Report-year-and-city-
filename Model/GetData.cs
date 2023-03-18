using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finaldigikala.Model
{
    class GetData
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ItemId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public int GrossAmount { get; set; }
        public string cityname { get; set; }
        public int Quantity { get; set; }
    }
}
