using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain
{
    [Table("User")]
    public class User : DomainStandard
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool? Activated_by_email { get; set; }
        public bool? Account_activated { get; set; }
        public string? Password { get; set; }
    }
}
