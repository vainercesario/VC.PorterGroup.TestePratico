using VC.PorterGroup.TestePratico.Infra.Core.Util.Mock;
using VC.PorterGroup.TestePratico.ObjetosUnicos.Dominio.Servico;

namespace VC.PorterGroup.TestePratico.ObjetosUnicos.Dominio.Teste;

[TestClass]
public class CheckagemListaObjetosUnicos
{
    [TestMethod]
    public void Remover_Duplicidades_Lista_De_Inteiros_Success()
    {
        var fakeLogger = new LoggerMock<ObjetosUnicosServico<int>>();

        List<int> listaOriginal = new() { 1, 2, 3, 2, 4, 5, 1, 3, 4, 3, 5 };
        List<int> listaUnicaEsperada = new() { 1, 2, 3, 4, 5 };

        IObjetosUnicosServico<int> servico = new ObjetosUnicosServico<int>(fakeLogger);
        List<int> listaUnica = servico.RemoverRedundancias(listaOriginal);

        CollectionAssert.AreEqual(listaUnicaEsperada, listaUnica);
    }

    [TestMethod]
    public void Remover_Duplicidades_Lista_De_Strings_Success()
    {
        var fakeLogger = new LoggerMock<ObjetosUnicosServico<string>>();

        List<string> listaOriginal = new() { "carro", "mala", "carteira", "mochila", "carteira", "carro", "carro" };
        List<string> listaUnicaEsperada = new() { "carro", "mala", "carteira", "mochila" };

        IObjetosUnicosServico<string> servico = new ObjetosUnicosServico<string>(fakeLogger);
        List<string> listaUnica = servico.RemoverRedundancias(listaOriginal);

        CollectionAssert.AreEqual(listaUnicaEsperada, listaUnica);
    }

    [TestMethod]
    public void Remover_Duplicidades_Lista_Diversos_Success()
    {
        var fakeLogger = new LoggerMock<ObjetosUnicosServico<object>>();

        List<object> listaOriginal = new() { 1, "carro", 2.5, 2.5, "2.5", "carro", 3, 1 };
        List<object> listaUnicaEsperada = new() { 1, "carro", 2.5, "2.5", 3 };

        IObjetosUnicosServico<object> servico = new ObjetosUnicosServico<object>(fakeLogger);
        List<object> listaUnica = servico.RemoverRedundancias(listaOriginal);

        CollectionAssert.AreEqual(listaUnicaEsperada, listaUnica);
    }
}