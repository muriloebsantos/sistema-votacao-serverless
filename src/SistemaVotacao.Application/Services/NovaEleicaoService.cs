using SistemaVotacao.Application.DataAccessContracts;
using SistemaVotacao.Application.Models.Requests;
using SistemaVotacao.Application.Models.Tables;
using System;
using System.Threading.Tasks;

namespace SistemaVotacao.Application.Services
{
    public class NovaEleicaoService : BaseService
    {
        private readonly IEleicaoDataAccess _eleicaoDataAccess;

        public NovaEleicaoService(IEleicaoDataAccess eleicaoDataAccess, NotificationService notificationService) : base (notificationService)
        {
            _eleicaoDataAccess = eleicaoDataAccess;
        }

        public async Task InserirEleicao(NovaEleicaoRequest novaEleicaoRequest)
        {
            if(!ValidarRequest(novaEleicaoRequest))
            {
                return;
            }

            var eleicaoExistente = await _eleicaoDataAccess.Obter(novaEleicaoRequest.Id);

            if(eleicaoExistente != null)
            {
                AddError(409, "Já existe uma eleição com esse código");
                return;
            }

            var eleicao = new Eleicao
            {
                Id = novaEleicaoRequest.Id,
                Nome = novaEleicaoRequest.Nome,
                Descricao = novaEleicaoRequest.Descricao,
                DataInclusao = DateTime.UtcNow
            };

            await _eleicaoDataAccess.Inserir(eleicao);
        }

        private  bool ValidarRequest(NovaEleicaoRequest novaEleicaoRequest)
        {
            if (string.IsNullOrWhiteSpace(novaEleicaoRequest.Id))
            {
                AddError(400, "Código da eleição é obrigatório");
                return false;
            }

            if (novaEleicaoRequest.Id.Length > 15)
            {
                AddError(400, "Código da eleição deve ter no máximo 15 caracteres");
                return false;
            }

            if (string.IsNullOrWhiteSpace(novaEleicaoRequest.Nome))
            {
                AddError(400, "O nome da eleição é obrigatório");
                return false;
            }

            if (novaEleicaoRequest.Nome.Length > 50)
            {
                AddError(400, "O nome da eleição deve ter no máximo 50 caracteres");
                return false;
            }

            return true;
        }
    }
}
