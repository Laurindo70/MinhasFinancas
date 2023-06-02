using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain
{
    public class DomainStandard
    {
        public Guid Id { get; set; }
        public DateTime? Created_at { get; set; }
        [ForeignKey("User_created")]
        [Required]
        public virtual User UserCreated { get; set; }
        public DateTime? Updated_at { get; set; }
        [ForeignKey("User_updated")]
        public virtual User UserUpdated { get; set; }
    }
}
