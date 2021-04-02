using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SistemaVotacao.Application.DataAccessContracts;
using SistemaVotacao.Application.Services;
using SistemaVotacao.DataAccess;

namespace SistemaVotacao.Lambda
{
    public static class Startup
    {
        public static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<NotificationService>();
            services.AddScoped<NovaEleicaoService>();
            services.AddScoped<IEleicaoDataAccess, EleicaoDataAccess>();
        }
    }
}
