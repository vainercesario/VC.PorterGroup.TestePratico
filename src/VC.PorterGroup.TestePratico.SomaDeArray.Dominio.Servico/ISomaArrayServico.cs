namespace VC.PorterGroup.TestePratico.SomaDeArray.Dominio.Servico;

public interface ISomaArrayServico
{
    Task<long> SomarAsync(IEnumerable<int> lista, CancellationToken cancellationToken);
}