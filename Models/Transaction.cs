using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Склад.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        public string Name { get; set; } // приход, расход

        public DateTime TransactionDate { get; set; }

        public string Description { get; set; }


        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }


        public int SupplierId { get; set; }
        [ForeignKey("ProductId")]
        public Supplier Supplier { get; set; }
    }
}
