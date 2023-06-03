using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain
{
    public class DomainStandard
    {
        public DomainStandard()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime? Created_at { get; set; } = null;
        public DateTime? Updated_at { get; set; } = null;
    }
}
