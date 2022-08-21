using BAL.AMenistop.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.AMenistop.Models
{
    public class StoreItem : BaseModel
    {
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int Quantity { get; set; }
    }
}
