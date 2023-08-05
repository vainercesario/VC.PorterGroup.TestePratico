using VC.PorterGroup.TestePratico.Infra.Core.Util.Mock;
using VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Interface;
using VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Servico;

namespace VC.PorterGroup.TestePratico.Teste.NumerosPorExtenso;

[TestClass]
public class VerificarUnidadesDeMilharPorExtenso
{
    [TestMethod]
    public void Conferir_Construcao_De_Numeros_De_Milhares_Por_Extenso_Sucesso()
    {
        var fakeLogger = new LoggerMock<MontarNumeroPorExtensoService>();

        List<(decimal numero, string retorno)> listaDeTestes = new()
        {
            (0, "0 -> Zero"),
            (1, "1 -> Um"),
            (10, "10 -> Dez"),
            (53, "53 -> Cinquenta e Três"),
            (100, "100 -> Cem"),
            (1000, "1000 -> Um Mil"),
            (1001, "1001 -> Um Mil, Um"),
            (2316578, "2316578 -> Dois Milhões, Trezentos e Dezesseis Mil, Quinhentos e Setenta e Oito"),
            (9456756756712345678, "9456756756712345678 -> Nove Quintilhões, Quatrocentos e Cinquenta e Seis Quatrilhões, Setecentos e Cinquenta e Seis Trilhões, Setecentos e Cinquenta e Seis Bilhões, Setecentos e Doze Milhões, Trezentos e Quarenta e Cinco Mil, Seiscentos e Setenta e Oito"),
            (1000001000001000001, "1000001000001000001 -> Um Quintilhão, Um Trilhão, Um Milhão, Um"),
            (-1000001000001000001, "1000001000001000001 -> Um Quintilhão, Um Trilhão, Um Milhão, Um negativo"),
            (1234567890123456789, "1234567890123456789 -> Um Quintilhão, Duzentos e Trinta e Quatro Quatrilhões, Quinhentos e Sessenta e Sete Trilhões, Oitocentos e Noventa Bilhões, Cento e Vinte e Três Milhões, Quatrocentos e Cinquenta e Seis Mil, Setecentos e Oitenta e Nove")
        };

        IMontarNumeroPorExtensoService montarNumeroPorExtensoService = new MontarNumeroPorExtensoService(fakeLogger);

        foreach (var (numero, retorno) in listaDeTestes)
        {
            Assert.AreEqual(retorno, montarNumeroPorExtensoService.GerarNumeroPorExtenso(numero));
        }
    }
}