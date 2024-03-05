using PfMsSalesPlatform.Domain.Aggregates.SalesBody.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PfMsSalesPlatform.Domain.Aggregates.Products.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public int Name { get; set; }

        [Required]
        [MaxLength(200)]
        public int Description { get; set; }
        
        [Required]
        public int Stock { get; set; }

        [Required]
        public decimal Price { get; set; }

        public bool ApplyClientDiscount { get; set; }

        [Required]
        public DateTime ActualizationDate { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }

        public virtual ICollection<Salebody> Salebody { get; set; }
    }
}
