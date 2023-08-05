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

        List<(string expressao, decimal resultado)> listaDeTestes = new()
        {
            ("1 + 1", 2m),
            ("2 * 3 + 4", 10m),
            ("2 + 3 * 4", 14m),
            ("3 / 2 * 2", 3m),
            ("3 / 2", 1.5m),
            ("2 + 2 + 4 + 10 * 2 / 4", 13m),
            ("2 + 2 / 4 + 10 * 2 / 4", 7.25m),
        };

        ProcessadorMatematicoServico processadorMatematicoService = new ProcessadorMatematicoServico(fakeLogger);

        foreach (var obj in listaDeTestes)
            Assert.AreEqual(obj.resultado, processadorMatematicoService.Calcular(obj.expressao));
    }

    [TestMethod]
    public void Calculadora_De_Expressao_De_String_Com_Insucesso_De_Expressao_Invalida()
    {
        var fakeLogger = new LoggerMock<ProcessadorMatematicoServico>();

        List<(string expressao, string erro)> listaDeTestes = new()
        {
            ("2 * + 4", "A expressão é inválida"),
            ("* 0 + 2 * 3", "A expressão é inválida"),
            ("2 * 3 abcd", "A expressão é inválida")
        };

        ProcessadorMatematicoServico processadorMatematicoService = new ProcessadorMatematicoServico(fakeLogger);

        foreach (var obj in listaDeTestes)
        {
            Exception excecao = Assert.ThrowsException<ArithmeticException>(() => processadorMatematicoService.Calcular(obj.expressao));
            Assert.AreEqual(obj.erro, excecao.Message);
        }
    }

    public void Calculadora_De_Expressao_De_String_Com_Insucesso_Na_Divisao()
    {
        var fakeLogger = new LoggerMock<ProcessadorMatematicoServico>();

        List<(string expressao, string erro)> listaDeTestes = new()
        {
            ("1 / 0", "A expressão possui divisão por zero, não é possível calcular."),
            ("1 + 1 + 1 / 0", "A expressão possui divisão por zero, não é possível calcular."),
        };

        IProcessadorMatematicoServico processadorMatematicoService = new ProcessadorMatematicoServico(fakeLogger);

        foreach (var obj in listaDeTestes)
        {
            Exception excecao = Assert.ThrowsException<ArithmeticException>(() => processadorMatematicoService.Calcular(obj.expressao));
            Assert.AreEqual(obj.erro, excecao.Message);
        }
    }
}