using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain
{
    public class DomainStandard
    {
        public Guid Id { get; set; }
        public DateTime CriadoEm { get; set; }
        [ForeignKey("CriadoPor")]
        public virtual User UsuarioCriado { get; set; }
        public DateTime AtualizadoEm { get; set; }
        [ForeignKey("UltimaAtualizacaoPor")]
        public virtual User UsuarioAtualizado { get; set; }
    }
}
