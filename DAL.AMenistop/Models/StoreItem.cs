using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.AMenistop.Models
{
    [Table("StoreItem")]
    internal class StoreItem : Entity
    {
        public string Name { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int Quantity { get; set; }
    }
}
