using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationWithBaseData.Models
{
    /// <summary>
    /// Категория товаров
    /// </summary>
    [Table("categories")]
    public class Category
    {
        [Key]
        [Column("categoryid")]
        public int? CategoryID { get; set; }

        [Required, StringLength(50)]
        [Column("name")]
        public string? Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
    