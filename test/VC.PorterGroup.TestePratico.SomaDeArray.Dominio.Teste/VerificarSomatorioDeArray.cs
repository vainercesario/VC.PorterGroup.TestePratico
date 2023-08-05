using VC.PorterGroup.TestePratico.SomaDeArray.Dominio.Servico;

namespace VC.PorterGroup.TestePratico.SomaDeArray.Dominio.Teste;

[TestClass]
public class VerificarSomatorioDeArray
{
    private readonly ISomaArrayServico _somaArrayService;

    public VerificarSomatorioDeArray(ISomaArrayServico somaArrayService)
    {
        this._somaArrayService = somaArrayService;
    }

    [TestMethod]
    public async Task ValidarSoma()
    {
        List<int> listaCheckagem = new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        IEnumerable<int> lista = listaCheckagem;

        Assert.AreEqual(lista.Sum(), await _somaArrayService.SomarAsync(lista, CancellationToken.None));
    }
}