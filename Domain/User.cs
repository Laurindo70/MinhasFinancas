using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain
{
    [Table("User")]
    public class User : DomainStandard
    {
        [Column(TypeName = "varchar(150)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Email { get; set; }
        [Required]
        public bool Activated_by_email { get; set; }
        [Required]
        public bool? Account_activated { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Password { get; set; }

    }
}
