using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationWithBaseData.Models
{
    /// <summary>
    /// Товар
    /// </summary>
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("productid")]
        public int ProductID { get; set; }

        [Required, StringLength(50)]
        [Column("name")] // имя колонки в базе PostgreSQL
        public string? Name { get; set; }

        [Column("price")]
        [Range(0.01, 10000)]
        public decimal? Price { get; set; }

        [Column("categoryid")]
        public int? CategoryID { get; set; }

        public Category? Category { get; set; }
    }
}