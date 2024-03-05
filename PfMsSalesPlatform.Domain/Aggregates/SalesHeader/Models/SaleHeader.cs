using PfMsSalesPlatform.Domain.Aggregates.Clients.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PfMsSalesPlatform.Domain.Aggregates.SalesBody.Models;

namespace PfMsSalesPlatform.Domain.Aggregates.SalesHeader.Models
{
    public class SaleHeader
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }

        [Required]
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        [Required]
        public decimal DiscontApply { get; set; }

        [Required]
        public decimal Total { get; set; }

        public virtual ICollection<Salebody> Salebody { get; set; }
    }
}
