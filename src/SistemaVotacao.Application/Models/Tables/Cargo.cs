using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVotacao.Application.Models.Tables
{
    public class Cargo
    {
        public string CargoId { get; set; } // SK
        public string EleicaoId { get; set; } // PK
        public string Descricao { get; set; }
    }
}
