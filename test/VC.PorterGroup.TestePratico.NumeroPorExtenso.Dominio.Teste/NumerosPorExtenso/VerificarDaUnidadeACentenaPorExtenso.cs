using VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Entidades;

namespace VC.PorterGroup.TestePratico.Teste.NumerosPorExtenso;

[TestClass]
public class VerificarDaUnidadeACentenaPorExtenso
{
    [TestMethod]
    [DataRow(9, "Nove")]
    [DataRow(1, "Um")]
    [DataRow(5, "Cinco")]
    [DataRow(2, "Dois")]
    public void Conferir_Construcao_De_Numeros_De_Unidade_Sucesso(int numero, string retorno)
    {
        Unidade unidade = new(numero);

        Assert.AreEqual(retorno, unidade.EscreverPorExtenso());
    }

    [TestMethod]
    [DataRow(91, "Noventa e Um")]
    [DataRow(10, "Dez")]
    [DataRow(20, "Vinte")]
    [DataRow(53, "Cinquenta e Três")]
    [DataRow(22, "Vinte e Dois")]
    public void Conferir_Construcao_De_Numeros_De_Dezenas_Sucesso(int numero, string retorno)
    {
        Dezena dezena = new(new Unidade(numero));

        Assert.AreEqual(retorno, dezena.EscreverPorExtenso());
    }

    [TestMethod]
    [DataRow(919, "Novecentos e Dezenove")]
    [DataRow(100, "Cem")]
    [DataRow(105, "Cento e Cinco")]
    [DataRow(200, "Duzentos")]
    [DataRow(533, "Quinhentos e Trinta e Três")]
    [DataRow(221, "Duzentos e Vinte e Um")]
    public void Conferir_Construcao_De_Numeros_De_Centenas_Sucesso(int numero, string retorno)
    {
        Centena centena = new(new Dezena(new Unidade(numero)));

        Assert.AreEqual(retorno, centena.EscreverPorExtenso());
    }
}