using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SistemaVotacao.Application.Models.Requests;
using SistemaVotacao.Application.Services;
using System.Threading.Tasks;

namespace SistemaVotacao.Lambda.Functions
{
    public class NovaEleicaoFunction : BaseFunction
    {
        public async override Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest apiProxyEvent, ILambdaContext context)
        {
            using (var serviceProvider = _serviceCollection.BuildServiceProvider())
            {
                var novaEleicaoService = serviceProvider.GetService<NovaEleicaoService>();

                var novaEleicaoRequest = JsonConvert.DeserializeObject<NovaEleicaoRequest>(apiProxyEvent.Body);

                await novaEleicaoService.InserirEleicao(novaEleicaoRequest);

                if(novaEleicaoService.HasError)
                {
                    return Error(novaEleicaoService.StatusCode, novaEleicaoService.Error);
                }

                return Created();
            }
        }
    }
}
