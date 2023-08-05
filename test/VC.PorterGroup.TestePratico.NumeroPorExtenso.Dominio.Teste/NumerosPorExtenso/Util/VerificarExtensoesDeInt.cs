using VC.PorterGroup.TestePratico.Infra.Core.Util.Enum;
using VC.PorterGroup.TestePratico.Infra.Core.Util.Extensao;

namespace VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Teste.Util;

[TestClass]
public class VerificarExtensoesDeInt
{
    [TestMethod]
    [DataRow(1, 1)]
    [DataRow(12, 2)]
    [DataRow(123, 3)]
    [DataRow(1234, 4)]
    [DataRow(12345, 5)]
    public void Conversar_De_Int_Para_Char_Com_Sucesso(int numero, int tamanho)
    {
        var valorTestado = numero.ConverterParaChar();

        Assert.AreEqual(valorTestado.Length, tamanho);
    }

    [TestMethod]
    [DataRow(1, CasasDeValores.Unidade, (byte)1)]
    [DataRow(12, CasasDeValores.Unidade, (byte)2)]
    [DataRow(12, CasasDeValores.Dezena, (byte)1)]
    [DataRow(123, CasasDeValores.Unidade, (byte)3)]
    [DataRow(123, CasasDeValores.Dezena, (byte)2)]
    [DataRow(123, CasasDeValores.Centena, (byte)1)]
    public void Retorno_De_Byte_Da_Posicao_Solicitada_Com_Sucesso(int numero, CasasDeValores casa, byte retorno)
    {
        byte valorTestado = numero.RetornaByteDaPosicao(casa);

        Assert.AreEqual(valorTestado, retorno);
    }

    [TestMethod]
    [DataRow(1, CasasDeValores.Dezena)]
    [DataRow(12, CasasDeValores.Centena)]
    [DataRow(1234, CasasDeValores.Unidade)]
    [DataRow(1234, CasasDeValores.Dezena)]
    [DataRow(1234, CasasDeValores.Centena)]
    public void Retorno_De_Byte_Da_Posicao_Solicitada_Com_Insucesso(int numero, CasasDeValores casa)
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => numero.RetornaByteDaPosicao(casa));
    }

    [TestMethod]
    [DataRow(1, CasasDeValores.Unidade)]
    [DataRow(12, CasasDeValores.Dezena)]
    [DataRow(123, CasasDeValores.Centena)]
    public void Retornar_Identificacao_De_Casas_Decimais_Do_Numero_Com_Sucesso(int numero, CasasDeValores casa)
    {
        var valorTestado = numero.IdentificarCasaDeUnidade();

        Assert.AreEqual(valorTestado, casa);
    }

    [TestMethod]
    [DataRow(1111)]
    public void Retornar_Identificacao_De_Casas_Decimais_Do_Numero_Com_Insucesso(int numero)
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => numero.IdentificarCasaDeUnidade());
    }

    [TestMethod]
    [DataRow(1111, 4)]
    [DataRow(1234, 4)]
    [DataRow(0012, 2)]
    public void Somador_De_Totais_De_Itens_Num_Int_Com_Sucesso(int numero, int total)
    {
        var valorTestado = numero.TotalItens();

        Assert.AreEqual(valorTestado, total);
    }

    [TestMethod]
    [DataRow(1111, 3)]
    [DataRow(1234, 3)]
    [DataRow(0012, 4)]
    public void Somador_De_Totais_De_Itens_Num_Int_Com_Inucesso(int numero, int total)
    {
        var valorTestado = numero.TotalItens();

        Assert.AreNotEqual(valorTestado, total);
    }
}