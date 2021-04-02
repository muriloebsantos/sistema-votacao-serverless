using System;

namespace SistemaVotacao.Application.Models.Tables
{
    public class Eleitor
    {
        public string Id { get; set; } // SK
        public string EleicaoId { get; set; } // PK
        public DateTime DataInclusao { get; set; }
    }
}
