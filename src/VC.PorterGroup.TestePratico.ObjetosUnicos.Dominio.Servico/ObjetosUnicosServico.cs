using Microsoft.Extensions.Logging;

namespace VC.PorterGroup.TestePratico.ObjetosUnicos.Dominio.Servico;

internal sealed class ObjetosUnicosServico<T> : IObjetosUnicosServico<T>
{
    private readonly ILogger<ObjetosUnicosServico<T>> logger;

    public ObjetosUnicosServico(ILogger<ObjetosUnicosServico<T>> logger)
    {
        this.logger = logger;
    }

    public List<T> RemoverRedundancias(List<T> lista)
    {
        logger.LogInformation("Realizar remoção de redundâncias");

        HashSet<T> itensUnicos = new();
        List<T> listaDeUnicos = new();

        foreach (T item in lista)
            if (itensUnicos.Add(item))
                listaDeUnicos.Add(item);

        return listaDeUnicos;
    }
}