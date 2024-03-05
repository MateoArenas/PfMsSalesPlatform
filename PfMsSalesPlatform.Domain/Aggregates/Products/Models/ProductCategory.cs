using System.ComponentModel.DataAnnotations;

namespace PfMsSalesPlatform.Domain.Aggregates.Products.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
