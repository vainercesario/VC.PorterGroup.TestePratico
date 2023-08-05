using Microsoft.Extensions.DependencyInjection.Extensions;
using VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Interface;
using VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Servico;

namespace Microsoft.Extensions.DependencyInjection;

public static class InstalarDependencias
{
    public static IServiceCollection AdicionarServicos(this IServiceCollection services)
    {
        services.TryAddScoped<IMontarNumeroPorExtensoService, MontarNumeroPorExtensoService>();

        return services;
    }
}