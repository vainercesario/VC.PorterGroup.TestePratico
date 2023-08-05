namespace VC.PorterGroup.TestePratico.Teste.NumerosPorExtenso;

[TestClass]
internal class VerificarUnidadesDeMilharPorExtenso
{
    [TestMethod]
    [DataRow(1, "1 -> Um")]
    [DataRow(10, "10 -> Dez")]
    [DataRow(53, "53 -> Cinquenta e Três")]
    [DataRow(9456756756712345678, "9456756756712345678 -> Nove Quintilhões, Quatrocentos e Cinquenta e Seis Quatrilhões, Setecentos e Cinquenta e Seis Trilhões, Setecentos e Cinquenta e Seis Bilhões, Setecentos e Doze Milhões, Trezentos e Quarenta e Cinco Mil, Seiscentos e Setenta e Oito")]
    [DataRow(1000001000001000001, "1000001000001000001 -> Um Quintilhão, Um Trilhão, Um Milhão, Um negativo.")]
    [DataRow(1234567890123456789, "1234567890123456789 -> Um Quintilhão, Duzentos e Trinta e Quatro Quatrilhões, Quinhentos e Sessenta e Sete Trilhões, Oitocentos e Noventa Bilhões, Cento e Vinte e Três Milhões, Quatrocentos e Cinquenta e Seis Mil, Setecentos e Oitenta e Nove")]
    public void VerificarNumerco(decimal numero, string retorno)
    {
        IMontarNumeroPorExtensoService montarNumeroPorExtensoService = new();

        Assert.AreEqual(retorno, montarNumeroPorExtensoService.GerarNumeroPorExtenso(numero));
    }
}