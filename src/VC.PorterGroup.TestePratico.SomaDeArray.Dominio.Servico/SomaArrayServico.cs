namespace VC.PorterGroup.TestePratico.SomaDeArray.Dominio.Servico;

internal sealed class SomaArrayServico : ISomaArrayServico
{
    public SomaArrayServico()
    {
    }

    public async Task<long> SomarAsync(IEnumerable<int> lista, CancellationToken cancellationToken)
    {
        long somatorio = 0;
        object objetoLock = new();

        await Task.Run(() =>
        {
            // Configurar opções de paralelismo
            ParallelOptions opcoes = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount, // Limita o paralelismo ao número de núcleos da CPU
                CancellationToken = cancellationToken // Associa o token de cancelamento
            };

            Parallel.ForEach(BuscarValor(lista), opcoes, numero =>
            {
                cancellationToken.ThrowIfCancellationRequested(); // Verifica se o cancelamento foi solicitado

                lock (objetoLock)
                {
                    somatorio += numero;
                }
            });
        }, cancellationToken);

        return somatorio;
    }

    private static IEnumerable<int> BuscarValor(IEnumerable<int> lista)
    {
        foreach (int valor in lista)
        {
            yield return valor;
        }
    }
}