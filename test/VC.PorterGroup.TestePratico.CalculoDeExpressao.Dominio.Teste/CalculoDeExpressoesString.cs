using VC.PorterGroup.TestePratico.CalculoDeExpressao.Dominio.Interface;
using VC.PorterGroup.TestePratico.CalculoDeExpressao.Dominio.Servico;
using VC.PorterGroup.TestePratico.Infra.Core.Util.Mock;

namespace VC.PorterGroup.TestePratico.CalculoDeExpressao.Dominio.Teste;

[TestClass]
public class CalculoDeExpressoesString
{
    [TestMethod]
    public void Calculadora_De_Expressao_De_String_Com_Sucesso()
    {
        var fakeLogger = new LoggerMock<ProcessadorMatematicoServico>();

        List<(string expressao, double resultado)> listaDeTestes = new()
        {
            ("- 1 + 1", 0),
            ("1 + 1", 2),
            ("2 * 3 + 4", 10),
            ("2 + 3 * 4", 14),
            ("3 / 2 * 2", 3),
            ("3 / 2", 1.5),
            ("2 + 2 + 4 + 10 * 2 / 4", 13),
            ("2 + 2 / 4 + 10 * 2 / 4", 7.5),
        };

        ProcessadorMatematicoServico processadorMatematicoService = new(fakeLogger);

        foreach (var (expressao, resultado) in listaDeTestes)
            Assert.AreEqual(resultado, processadorMatematicoService.Calcular(expressao));
    }

    [TestMethod]
    public void Calculadora_De_Expressao_De_String_Com_Insucesso_De_Expressao_Invalida()
    {
        var fakeLogger = new LoggerMock<ProcessadorMatematicoServico>();

        List<(string expressao, string erro)> listaDeTestes = new()
        {
            ("2 * + 4", "A expressão é inválida."),
            ("* 0 + 2 * 3", "A expressão é inválida."),
            ("2 * 3 abcd", "A expressão é inválida.")
        };

        ProcessadorMatematicoServico processadorMatematicoService = new(fakeLogger);

        foreach (var (expressao, erro) in listaDeTestes)
        {
            Exception excecao = Assert.ThrowsException<ArithmeticException>(() => processadorMatematicoService.Calcular(expressao));
            Assert.AreEqual(erro, excecao.Message);
        }
    }

    public void Calculadora_De_Expressao_De_String_Com_Insucesso_Na_Divisao()
    {
        var fakeLogger = new LoggerMock<ProcessadorMatematicoServico>();

        List<(string expressao, string erro)> listaDeTestes = new()
        {
            ("1 / 0", "Não é possível realizar divisão por zero."),
            ("1 + 1 + 1 / 0", "Não é possível realizar divisão por zero."),
        };

        IProcessadorMatematicoServico processadorMatematicoService = new ProcessadorMatematicoServico(fakeLogger);

        foreach (var (expressao, erro) in listaDeTestes)
        {
            Exception excecao = Assert.ThrowsException<ArithmeticException>(() => processadorMatematicoService.Calcular(expressao));
            Assert.AreEqual(erro, excecao.Message);
        }
    }
}