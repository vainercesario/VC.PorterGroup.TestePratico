using VC.PorterGroup.TestePratico.CalculoDeExpressao.Dominio.Entidade;

namespace VC.PorterGroup.TestePratico.CalculoDeExpressao.Dominio.Teste.Unidade;

[TestClass]
public class TesteUnidadeExpressaoMatematica
{
    [TestMethod]
    public void Expressao_Matematica_Valida_Com_Sucesso()
    {
        List<(string expressao, (bool valido, List<string>? erro) validacao)> listaDeTestes = new()
        {
            (new("21 * 4 + 5"), (true, null)),
            (new("37 + 1 + 4* 2"), (true, null)),
            (new("- 12 + 1 + 4* 2"), (true, null)),
        };

        foreach (var obj in listaDeTestes)
        {
            ExpressaoMatematica expressaoMatematica = new(obj.expressao);
            Assert.AreEqual(obj.validacao, expressaoMatematica.Validar());
        }
    }

    [TestMethod]
    public void Expressao_Matematica_Invalida_Com_Sucesso()
    {
        List<(string expressao, (bool valido, List<string> erro) validacao)> listaDeTestes = new()
        {
            (new("* 2 * 4"), (false, new List<string>(){"A expressão é inválida." })),
            (new("12 / 0 + 13"), (false, new List<string>(){"Não é possível realizar divisão por zero."}))
        };

        foreach (var (expressao, validacao) in listaDeTestes)
        {
            ExpressaoMatematica expressaoMatematica = new(expressao);
            CollectionAssert.AreEqual(validacao.erro, expressaoMatematica.Validar().Erro);
        }
    }

    [TestMethod]
    public void Expressao_Matematica_Calculada_Com_Sucesso()
    {
        List<(string expressao, double valor)> listaDeTestes = new()
        {
            (new("2 * 4"), 8),
            (new("12 / 2 + 13"), 19),
            (new("40 + 12 / 2 + 13"), 59)
        };

        foreach (var (expressao, valor) in listaDeTestes)
        {
            ExpressaoMatematica expressaoMatematica = new(expressao);
            Assert.AreEqual(valor, expressaoMatematica.Calcular());
        }
    }
}