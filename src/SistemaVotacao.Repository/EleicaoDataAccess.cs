using SistemaVotacao.Application.DataAccessContracts;
using SistemaVotacao.Application.Models.Tables;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVotacao.DataAccess
{
    public class EleicaoDataAccess :  BaseDataAccess, IEleicaoDataAccess
    {
        public async Task<Eleicao> Obter(string codigo)
        {
            return (await _context.QueryAsync<Eleicao>(codigo).GetNextSetAsync()).FirstOrDefault();
        }

        public async Task Inserir(Eleicao eleicao)
        {
            await _context.SaveAsync(eleicao);
        }
    }
}
