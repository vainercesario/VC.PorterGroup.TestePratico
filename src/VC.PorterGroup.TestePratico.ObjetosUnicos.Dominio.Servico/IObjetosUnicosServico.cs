namespace VC.PorterGroup.TestePratico.ObjetosUnicos.Dominio.Servico;

public interface IObjetosUnicosServico<T>
{
    List<T> RemoverRedundancias(List<T> lista);
}