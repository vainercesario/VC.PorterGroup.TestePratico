using Microsoft.Extensions.DependencyInjection.Extensions;
using VC.PorterGroup.TestePratico.CalculoDeExpressao.Dominio.Interface;
using VC.PorterGroup.TestePratico.CalculoDeExpressao.Dominio.Servico;

namespace Microsoft.Extensions.DependencyInjection;

public static class InstalarDependencias
{
    public static IServiceCollection AdicionarCalculoExpressaoServicos(this IServiceCollection services)
    {
        services.TryAddScoped<IProcessadorMatematicoServico, ProcessadorMatematicoServico>();

        return services;
    }
}