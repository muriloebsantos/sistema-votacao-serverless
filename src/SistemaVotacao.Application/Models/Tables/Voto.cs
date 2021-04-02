using System;

namespace SistemaVotacao.Application.Models.Tables
{
    public class Voto
    {
        public string CargoId { get; set; } // PK
        public string CandidatoId { get; set; }
        public string EleitorId { get; set; } // SK
        public DateTime DataInclusao { get; set; }
    }
}
