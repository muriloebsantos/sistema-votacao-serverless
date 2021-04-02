using SistemaVotacao.Application.Models.Tables;
using System.Threading.Tasks;

namespace SistemaVotacao.Application.DataAccessContracts
{
    public interface IEleicaoDataAccess
    {
        Task Inserir(Eleicao eleicao);

        Task<Eleicao> Obter(string codigo);
    }
}
