using PfMsSalesPlatform.Domain.Aggregates.Products.Models;
using PfMsSalesPlatform.Domain.Aggregates.SalesHeader.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PfMsSalesPlatform.Domain.Aggregates.SalesBody.Models
{
    public class Salebody
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SaleHeaderId { get; set; }
        [ForeignKey("SaleHeaderId")]
        public virtual SaleHeader SaleHeader { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
