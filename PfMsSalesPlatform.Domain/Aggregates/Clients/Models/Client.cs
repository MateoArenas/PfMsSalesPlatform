using PfMsSalesPlatform.Domain.Aggregates.SalesHeader.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PfMsSalesPlatform.Domain.Aggregates.Clients.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Lastname { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int ClientTypeId { get; set; }
        [ForeignKey("ClientTypeId")]
        public virtual ClientType ClientType { get; set; }

        public virtual ICollection<SaleHeader> SaleHeaders { get; set; }
    }
}
