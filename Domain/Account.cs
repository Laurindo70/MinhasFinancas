using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain
{
    [Table("Account")]
    public class Account : DomainStandard
    {
        public Guid Id { get; set; }
        public Double Available_value { get; set; }
        public Double Amount_received_per_month { get; set; }
        public Double Value_credit { get; set; }
        [ForeignKey("Responsible_user")]
        public virtual User ResponsibleUser { get; set; }
    }
}
