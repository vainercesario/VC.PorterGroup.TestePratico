using VC.PorterGroup.TestePratico.Infra.Core.Util.Mock;
using VC.PorterGroup.TestePratico.SomaDeArray.Dominio.Servico;

namespace VC.PorterGroup.TestePratico.SomaDeArray.Dominio.Teste;

[TestClass]
public class VerificarSomatorioDeArray
{
    [TestMethod]
    public async Task Converir_Soma_De_Inteiros_De_Array_Com_Sucesso()
    {
        var fakeLogger = new LoggerMock<SomaArrayServico>();
        ISomaArrayServico _somaArrayService = new SomaArrayServico(fakeLogger);

        List<int> listaCheckagem1 = new() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        List<int> listaCheckagem2 = new() { 32, 145, 21, 31, 58, 49, 321, 1, 93, 158, 43, 47, 79, 1, 2, 3 };

        IEnumerable<int> lista1 = listaCheckagem1;
        IEnumerable<int> lista2 = listaCheckagem2;

        Assert.AreEqual((long)lista1.Sum(), await _somaArrayService.SomarAsync(lista1, CancellationToken.None));
        Assert.AreEqual((long)lista2.Sum(), await _somaArrayService.SomarAsync(lista2, CancellationToken.None));
    }
}