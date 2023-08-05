using VC.PorterGroup.TestePratico.Infra.Core.Util.Enum;
using VC.PorterGroup.TestePratico.Infra.Core.Util.Extensao;

namespace VC.PorterGroup.TestePratico.Teste.NumerosPorExtenso.Util;

[TestClass]
public class VerificarExtensoesDeInt
{
    [TestMethod]
    [DataRow(1, 1)]
    [DataRow(12, 2)]
    [DataRow(123, 3)]
    [DataRow(1234, 4)]
    [DataRow(12345, 5)]
    public void VerificarConversaoParaChar(int numero, byte tamanho)
    {
        var valorTestado = numero.ConverterParaChar();

        Assert.AreEqual(valorTestado.Length, tamanho);
        Assert.IsTrue(valorTestado is char[]);
    }

    [TestMethod]
    [DataRow(1, CasasDeValores.Unidade, 1)]
    [DataRow(12, CasasDeValores.Unidade, 1)]
    [DataRow(12, CasasDeValores.Dezena, 2)]
    [DataRow(123, CasasDeValores.Unidade, 1)]
    [DataRow(123, CasasDeValores.Dezena, 2)]
    [DataRow(123, CasasDeValores.Centena, 3)]
    [DataRow(1234, CasasDeValores.Unidade, 1)]
    [DataRow(1234, CasasDeValores.Dezena, 2)]
    [DataRow(1234, CasasDeValores.Centena, 3)]
    public void VerificarRetornoDeByteDaPosicaoValido(int numero, CasasDeValores casa, byte retorno)
    {
        var valorTestado = numero.RetornaByteDaPosicao(casa);

        Assert.AreEqual(valorTestado, retorno);
    }

    [TestMethod]
    [DataRow(1, CasasDeValores.Dezena)]
    [DataRow(12, CasasDeValores.Centena)]
    [DataRow(1234, CasasDeValores.Unidade)]
    [DataRow(1234, CasasDeValores.Dezena)]
    [DataRow(1234, CasasDeValores.Centena)]
    public void VerificarRetornoDeByteDaPosicaoInvalido(int numero, CasasDeValores casa)
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => numero.RetornaByteDaPosicao(casa));
    }

    [TestMethod]
    [DataRow(1, CasasDeValores.Unidade)]
    [DataRow(12, CasasDeValores.Dezena)]
    [DataRow(123, CasasDeValores.Centena)]
    public void VerificarIdentificacaoDaCasaDaUnidadeValido(int numero, CasasDeValores casa)
    {
        var valorTestado = numero.IdentificarCasaDeUnidade();

        Assert.AreEqual(valorTestado, casa);
    }

    [TestMethod]
    [DataRow(1111)]
    public void VerificarIdentificacaoDaCasaDaUnidadeInvalido(int numero)
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => numero.IdentificarCasaDeUnidade());
    }

    [TestMethod]
    [DataRow(1111, 4)]
    [DataRow(1234, 4)]
    [DataRow(0012, 2)]
    public void VerificarTotalItensValido(int numero, int total)
    {
        var valorTestado = numero.TotalItens();

        Assert.AreEqual(valorTestado, total);
    }

    [TestMethod]
    [DataRow(1111, 3)]
    [DataRow(1234, 3)]
    [DataRow(0012, 4)]
    public void VerificarTotalItensInvalido(int numero, int total)
    {
        var valorTestado = numero.TotalItens();

        Assert.AreNotEqual(valorTestado, total);
    }
}