using VC.PorterGroup.TestePratico.CalculoDeExpressao.Dominio.Entidade;

namespace VC.PorterGroup.TestePratico.CalculoDeExpressao.Dominio.Teste.Unidade;

[TestClass]
public class TesteUnidadeExpressaoMatematica
{
    [TestMethod]
    public void Expressao_Matematica_Quebrada_Em_Array_De_Itens()
    {
        List<(string expressao, List<string> itens)> listaDeTestes = new()
        {
            ("2 * 4", new List<string>(){"2","*","4"}),
            ("21 * 4 + 5", new List<string>(){"21", "*", "4", "+", "5"}),
            ("37 + 1 + 4* 2", new List<string>(){"37","+", "1", "+","4","*","2"}),
            ("- 12 + 1 + 4* 2", new List<string>(){"0", "-", "12","+", "1", "+","4","*","2"})
        };

        ExpressaoMatematica expressaoMatematica = new(expressao);

        foreach (var obj in listaDeTestes)
        {
            CollectionAssert.AreEqual(obj.itens, expressaoMatematica.Posicoes);
        }
    }

    [TestMethod]
    public void Expressao_Matematica_Valida_Com_Sucesso()
    {
        List<(string expressao, (bool valido, string erro) validacao)> listaDeTestes = new()
        {
            ("21 * 4 + 5", (true,"")),
            ("37 + 1 + 4* 2", (true,"")),
            ("- 12 + 1 + 4* 2", (true,"")),
        };

        ExpressaoMatematica expressaoMatematica = new(expressao);

        foreach (var obj in listaDeTestes)
        {
            Assert.AreEqual(obj.validacao, expressaoMatematica.Validar());
        }
    }

    [TestMethod]
    public void Expressao_Matematica_Invalida_Com_Sucesso()
    {
        List<(string expressao, (bool valido, string erro) validacao)> listaDeTestes = new()
        {
            ("* 2 * 4", (false, "A expressão é inválida.")),
            ("12 / 0 + 13", (false, "A expressão possui divisão por zero, não é possível calcular."))
        };

        ExpressaoMatematica expressaoMatematica = new(expressao);

        foreach (var obj in listaDeTestes)
        {
            Assert.AreEqual(obj.validacao, expressaoMatematica.Validar());
        }
    }

    [TestMethod]
    public void Expressao_Matematica_Calculada()
    {
    }
}