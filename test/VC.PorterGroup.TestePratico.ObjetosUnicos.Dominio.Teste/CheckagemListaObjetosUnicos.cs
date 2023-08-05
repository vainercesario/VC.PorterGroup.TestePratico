namespace VC.PorterGroup.TestePratico.ObjetosUnicos.Dominio.Teste;

[TestClass]
public class CheckagemListaObjetosUnicos
{
    [TestMethod]
    public void Remover_Duplicidades_Lista_De_Inteiros_Success()
    {
        List<int> originalList = new List<int> { 1, 2, 3, 2, 4, 5, 1, 3, 4, 3, 5 };
        List<int> expectedUniqueList = new List<int> { 1, 2, 3, 4, 5 };

        IObjetosUnicosService service = new ObjetosUnicosService();
        List<int> uniqueList = service.RemoverRedundancias(originalList);

        CollectionAssert.AreEqual(expectedUniqueList, uniqueList);
    }

    [TestMethod]
    public void Remover_Duplicidades_Lista_De_Strings_Success()
    {
        List<string> originalList = new List<string> { "carro", "mala", "carteira", "mochila", "carteira", "carro", "carro" };
        List<string> expectedUniqueList = new List<string> { "carro", "mala", "carteira" };

        IObjetosUnicosService service = new ObjetosUnicosService();
        List<string> uniqueList = service.RemoverRedundancias(originalList);

        CollectionAssert.AreEqual(expectedUniqueList, uniqueList);
    }

    [TestMethod]
    public void Remover_Duplicidades_Lista_Diversos_Success()
    {
        List<object> originalList = new List<object> { 1, "carro", 2.5, "carro", 3, 1 };
        List<object> expectedUniqueList = new List<object> { 1, "carro", 2.5, 3 };

        IObjetosUnicosService service = new ObjetosUnicosService();
        List<object> uniqueList = service.RemoverRedundancias(originalList);

        CollectionAssert.AreEqual(expectedUniqueList, uniqueList);
    }
}