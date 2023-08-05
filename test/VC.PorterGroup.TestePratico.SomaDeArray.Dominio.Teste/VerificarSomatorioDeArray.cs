namespace VC.PorterGroup.TestePratico.SomaDeArray.Dominio.Teste;

[TestClass]
public class VerificarSomatorioDeArray
{
    [TestMethod]
    public void ValidarSoma()
    {
        var lista = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        ISomaArrayService somaArray = new SomaArrayService();

        Assert.AreEqual(lista.Sum(), somaArray.Somar(lista));
    }
}