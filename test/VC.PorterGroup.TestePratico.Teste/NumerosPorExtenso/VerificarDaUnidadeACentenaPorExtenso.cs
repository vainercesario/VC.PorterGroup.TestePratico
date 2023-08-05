namespace VC.PorterGroup.TestePratico.Teste.NumerosPorExtenso;

[TestClass]
public class VerificarDaUnidadeACentenaPorExtenso
{
    [TestMethod]
    [DataRow(9, "Nove")]
    [DataRow(1, "Nove")]
    [DataRow(5, "Cinco")]
    [DataRow(2, "Dois")]
    public void VerificarNumerosDeUnidade(int numero, string retorno)
    {
        Unidades unidade = new Unidades(numero);

        Assert.AreEqual(unidade.EscreverPorExtenso(), retorno);
    }

    [TestMethod]
    [DataRow(91, "Noventa e Um")]
    [DataRow(10, "Dez")]
    [DataRow(20, "Vinte")]
    [DataRow(53, "Cinquenta e Três")]
    [DataRow(22, "Vinte e Dois")]
    public void VerificarNumerosDeDezenas(int numero, string retorno)
    {
        Dezenas dezena = new(new Unidades(numero));

        Assert.AreEqual(dezena.EscreverPorExtenso(), retorno);
    }

    [TestMethod]
    [DataRow(919, "Novecentos e Dezenove")]
    [DataRow(100, "Cem")]
    [DataRow(200, "Duzentos")]
    [DataRow(533, "Quinhentos e Trinta e Três")]
    [DataRow(221, "Duzentos e Vinte e Um")]
    public void VerificarNumerosDeCentenas(int numero, string retorno)
    {
        Centenas centena = new(new Dezenas(new Unidades(numero)));

        Assert.AreEqual(centena.EscreverPorExtenso(), retorno);
    }
}