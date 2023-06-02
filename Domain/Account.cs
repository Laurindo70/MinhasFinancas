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
        [ForeignKey("Responsible_user")]
        [Required]
        public virtual User ResponsibleUser { get; set; }

    }
}
