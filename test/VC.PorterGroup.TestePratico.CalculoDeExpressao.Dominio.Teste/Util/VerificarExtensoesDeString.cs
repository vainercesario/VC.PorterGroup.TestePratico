using VC.PorterGroup.TestePratico.Infra.Core.Util.Extensao;

namespace VC.PorterGroup.TestePratico.CalculoDeExpressao.Dominio.Teste.Util;

[TestClass]
public class VerificarExtensoesDeString
{
    [TestMethod]
    [DataRow("T e s t e", "Teste")]
    [DataRow("          Teste         ", "Teste")]
    [DataRow("                   Teste", "Teste")]
    [DataRow("Teste                   ", "Teste")]
    public void Remover_Espacos_Com_Sucesso(string texto, string retorno)
    {
        var valorTestado = texto.RemoverEspacos();

        Assert.AreEqual(retorno, valorTestado);
    }

    [TestMethod]
    public void Validar_Conversao_Lista_De_String_Em_String()
    {
        List<(List<string> textos, string retorno)> listaDeTestes = new()
        {
            (new List<string>(){"Teste","Teste","Teste"}, "Teste, Teste, Teste"),
            (new List<string>(){"Teste...","Teste...","Teste..."}, "Teste..., Teste..., Teste...")
        };

        foreach (var (textos, retorno) in listaDeTestes)
        {
            Assert.AreEqual(retorno, textos.Unificado(", "));
        }
    }

    [TestMethod]
    [DataRow("", true)]
    [DataRow(null, true)]
    public void String_Em_Branco_Com_Sucesso(string texto, bool retorno)
    {
        Assert.AreEqual(retorno, texto.EmBranco());
    }

    [TestMethod]
    [DataRow("2*3*4*+4", true)]
    [DataRow("2*3*4/-4", true)]
    [DataRow("2*3*4-4", false)]
    public void Valida_Operador_Matematico_Em_Sequencia_String_com_Sucesso(string expressao, bool resultado)
    {
        var valorTestado = expressao.PossuiOperadorMatematicoSequencial();
        Assert.AreEqual(resultado, valorTestado);
    }

    [TestMethod]
    [DataRow("+2*3*4+4", true)]
    [DataRow("*2*3*4-4", true)]
    [DataRow("-2*3*4-4", false)]
    public void Valida_Se_Possui_Operador_Matematico_No_Inicio_Com_Sucesso(string expressao, bool resultado)
    {
        var valorTestado = expressao.PossuiOperadorMatematicoAoInicio();
        Assert.AreEqual(resultado, valorTestado);
    }

    [TestMethod]
    [DataRow("2*3*4+4+", true)]
    [DataRow("2*3*4-4*", true)]
    [DataRow("-2*3*4-4", false)]
    public void Valida_Se_Possui_Operador_Matematico_No_Final_Com_Sucesso(string expressao, bool resultado)
    {
        var valorTestado = expressao.PossuiOperadorMatematicoAoFinal();
        Assert.AreEqual(resultado, valorTestado);
    }

    [TestMethod]
    [DataRow("2*3/0*4+4", true)]
    [DataRow("2/0+2*3*4-4", true)]
    [DataRow("2*3*4-4", false)]
    public void Valida_Existencia_Divisao_Por_Zero(string expressao, bool resultado)
    {
        var valorTestado = expressao.PossuiOperadorMatematicoDivisaoPorZero();
        Assert.AreEqual(resultado, valorTestado);
    }

    [TestMethod]
    [DataRow("2*3/0*4+4-aaaa", true)]
    [DataRow("2/0+2*3*4r-4", true)]
    [DataRow("2*3*4-4", false)]
    public void Valida_Existencia_Caractere_Na_Expressao_Com_Sucesso(string expressao, bool resultado)
    {
        var valorTestado = expressao.PossuiCaracteresNaExpressaoMatematica();
        Assert.AreEqual(resultado, valorTestado);
    }
}