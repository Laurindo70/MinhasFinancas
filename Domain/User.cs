using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain
{
    [Table("Usuario")]
    public class User : DomainStandard
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public bool AtivaPorEmail { get; set; }
        public bool ContaAtivada { get; set; }
        public string? Senha { get; set; }
    }
}
