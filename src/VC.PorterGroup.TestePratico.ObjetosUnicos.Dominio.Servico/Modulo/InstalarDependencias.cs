using Microsoft.Extensions.DependencyInjection.Extensions;
using VC.PorterGroup.TestePratico.ObjetosUnicos.Dominio.Servico;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class InstalarDependencias
{
    public static IServiceCollection AdicionarObjetosUnicosServicos(this IServiceCollection services)
    {
        services.TryAddScoped(typeof(IObjetosUnicosServico<>), typeof(ObjetosUnicosServico<>));

        return services;
    }
}