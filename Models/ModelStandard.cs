namespace MinhasFinancas.Models
{
    public class ModelStandard
    {
        public ModelStandard()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid UltimaAtualizacaoPor { get; set; }
        public Guid CriadoPor { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }

    }
}
