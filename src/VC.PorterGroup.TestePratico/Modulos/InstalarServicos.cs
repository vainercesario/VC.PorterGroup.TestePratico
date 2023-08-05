namespace Microsoft.Extensions.DependencyInjection;

public static class InstalarDependencias
{
    public static IServiceCollection AdicionarServicos(this IServiceCollection services)
    {
        services.AdicionarNumeroPorExtensoServicos();
        services.AdicionarSomaDeArrayServicos();

        return services;
    }
}