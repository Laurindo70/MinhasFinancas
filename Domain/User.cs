using MinhasFinancas.Domain.TabelsOfRelation;
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
        public bool? Activated_by_email { get; set; } = null;
        public bool? Account_activated { get; set; } = null;
        [Required]
        public byte[] Password { get; set; }
        [Column("Password_salt")]
        public byte[] PasswordSalt { get; set; }

        //Relãção de muitos para muitos - contas;
        public List<Account> Accounts { get; } = new();

        //Relação de um para muitos - contas;
        public ICollection<Account> Users_account { get; set; }

    }
}
