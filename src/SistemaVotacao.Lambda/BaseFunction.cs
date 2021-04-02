using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaVotacao.Lambda
{
    public abstract class BaseFunction
    {
        protected readonly ServiceCollection _serviceCollection = new ServiceCollection();

        protected BaseFunction()
        {
            Startup.ConfigureServices(_serviceCollection);
        }

        public abstract Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest apiProxyEvent, ILambdaContext context);

        protected static APIGatewayProxyResponse Created()
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = 201,
                Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
            };
        }

        protected static APIGatewayProxyResponse Error(int status, string message)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = status,
                Body = message,
                Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
            };
        }
    }
}
