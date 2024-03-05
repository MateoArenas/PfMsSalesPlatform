using System.ComponentModel.DataAnnotations;

namespace PfMsSalesPlatform.Domain.Aggregates.Clients.Models
{
    public class ClientType
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string TypeName { get; set; }
        
        [Required]
        public decimal Discount { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
