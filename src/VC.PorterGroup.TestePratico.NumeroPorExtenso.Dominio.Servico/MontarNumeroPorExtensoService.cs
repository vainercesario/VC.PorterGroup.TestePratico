using VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Entidades;
using VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Interface;

namespace VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Servico;

public sealed class MontarNumeroPorExtensoService : IMontarNumeroPorExtensoService
{
    private const int POSICAO_INICIAL = 0;
    private const int POSICOES_DAS_CENTENAS = 3;

    public MontarNumeroPorExtensoService()
    {
    }

    public string GerarNumeroPorExtenso(decimal numero)
    {
        if (numero == 0)
            return "0 -> Zero";

        if (numero < 0)
            return GerarNumeroPorExtenso(Math.Abs(numero)) + " negativo";

        ComposicaoDoNumeral(numero,
            out string numeroEmString,
            out int posicoesPrimeiraCentena,
            out int primeiraUnidade);

        var milhar = new Milhar(numeroEmString, primeiraUnidade, posicoesPrimeiraCentena);

        return milhar.EscreverPorExtenso();
    }

    private static void ComposicaoDoNumeral(decimal numero, out string numeroEmString, out int posicoes, out int primeiraUnidade)
    {
        numeroEmString = numero.ToString();

        posicoes = numeroEmString.Length / POSICOES_DAS_CENTENAS;

        primeiraUnidade = numeroEmString.Length % POSICOES_DAS_CENTENAS;

        if (primeiraUnidade == POSICAO_INICIAL)
        {
            primeiraUnidade += POSICOES_DAS_CENTENAS;
            posicoes--;
        }
    }
}