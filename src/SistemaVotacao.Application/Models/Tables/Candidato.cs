namespace SistemaVotacao.Application.Models.Tables
{
    public class Candidato
    {
        public string Id { get; set; } // SK
        public string CargoId { get; set; } // PK
        public string Nome { get; set; }
        public string Foto { get; set; }
    }
}
