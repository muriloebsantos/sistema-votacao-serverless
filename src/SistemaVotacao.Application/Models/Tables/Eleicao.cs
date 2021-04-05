using Amazon.DynamoDBv2.DataModel;
using System;

namespace SistemaVotacao.Application.Models.Tables
{
    [DynamoDBTable("sv2_eleicao")]
    public class Eleicao
    {
        [DynamoDBHashKey]
        public string Id { get; set; } 
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [DynamoDBRangeKey]
        public DateTime DataInclusao { get; set; }
    }
}
