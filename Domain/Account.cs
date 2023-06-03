using MinhasFinancas.Domain.TabelsOfRelation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain
{
    [Table("Account")]
    public class Account : DomainStandard
    {
        [Required]
        public Double Available_value { get; set; }
        [Required]
        public Double Amount_received_per_month { get; set; }
        [Required]
        public Double Value_credit { get; set; }

        //Relãção de muitos para muitos - usuarios;
        public List<User> Users { get; } = new();

        //Relação de um para muitos - usuarios;
        public Guid Responsible_user { get; set; }
        public User User { get; set; } = null!; 

    }
}
