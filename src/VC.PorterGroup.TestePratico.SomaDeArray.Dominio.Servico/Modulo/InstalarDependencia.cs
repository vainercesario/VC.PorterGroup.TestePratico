using Microsoft.Extensions.DependencyInjection.Extensions;
using VC.PorterGroup.TestePratico.SomaDeArray.Dominio.Servico;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class InstalarDependencias
{
    public static IServiceCollection AdicionarSomaDeArrayServicos(this IServiceCollection services)
    {
        services.TryAddScoped<ISomaArrayServico, SomaArrayServico>();

        return services;
    }
}