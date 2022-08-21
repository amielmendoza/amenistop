using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AMenistop.DTO
{
    public class StoreItemDTO : BaseDTO
    {
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int Quantity { get; set; }
    }
}
