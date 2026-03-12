using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationWithBaseData.Models
{
    /// <summary>
    /// Заказ
    /// </summary>
    [Table("orders")]
    public class Order
    {
        [Key, Column("orderid")]
        public int OrderID { get; set; }

        [Column("productid")]
        public int ProductID { get; set; }

        public Product? Product { get; set; }

        [Column("quantity")]
        [Range(1, 1000)]
        public int Quantity { get; set; }

        [Column("orderdate")]
        public DateTime OrderDate { get; set; }
    }
}