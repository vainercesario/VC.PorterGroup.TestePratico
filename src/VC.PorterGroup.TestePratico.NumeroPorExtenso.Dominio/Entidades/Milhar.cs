using VC.PorterGroup.TestePratico.Infra.Core.Util.Enum;
using VC.PorterGroup.TestePratico.Infra.Core.Util.Extensao;
using VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Base;

namespace VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Entidades;

public class Milhar
{
    private static readonly string[] MILHAR_SINGULAR = { "", "Mil", "Milhão", "Bilhão", "Trilhão", "Quatrilhão", "Quintilhão" };
    private static readonly string[] MILHAR_PLURAL = { "", "Mil", "Milhões", "Bilhões", "Trilhões", "Quatrilhões", "Quintilhões" };

    public Milhar(string numero, int posicoesPrimeiraCentena, int quantidadeDeCentenas)
    {
        ListaDeCentenas = new();
        Numero = numero;
        PosicoesPrimeiraCentena = posicoesPrimeiraCentena;
        QuantidadeDeCentenas = quantidadeDeCentenas;

        MontaUnidadesDeMilhar();
    }

    private string Numero { get; set; }
    private int QuantidadeDeCentenas { get; set; }
    private int PosicoesPrimeiraCentena { get; set; }

    private List<NumeralComponente> ListaDeCentenas { get; set; }

    public string EscreverPorExtenso()
    {
        string? retorno = "";

        for (int i = 0; i < ListaDeCentenas.Count; i++)
        {
            var composicaoValor = ListaDeCentenas[i];

            if (composicaoValor.Numero > 0)
            {
                retorno +=
                    $"{(i == 0 ? "" : ", ")}" +
                    $"{composicaoValor.EscreverPorExtenso()}" +
                    $"{PopularUnidadeMilhar(i, composicaoValor.Numero)}";
            }
        }

        return $"{Numero} -> {retorno.Trim()}";
    }

    private void MontaUnidadesDeMilhar()
    {
        AdicionarCentena(int.Parse(Numero[..PosicoesPrimeiraCentena]));

        for (int i = QuantidadeDeCentenas; i > 0; i--)
        {
            var posicaoInicioProximaCentena = PosicoesPrimeiraCentena + ((QuantidadeDeCentenas - i) * 3);
            AdicionarCentena(int.Parse(Numero.Substring(posicaoInicioProximaCentena, 3)));
        }
    }

    private void AdicionarCentena(int numeral)
    {
        Unidade unidade = new(numeral);

        switch (numeral.IdentificarCasaDeUnidade())
        {
            case CasasDeValores.Centena:
                Dezena dezenaCentena = new(unidade);
                ListaDeCentenas.Add(new Centena(dezenaCentena));
                break;

            case CasasDeValores.Dezena:
                ListaDeCentenas.Add(new Dezena(unidade));
                break;

            case CasasDeValores.Unidade:
                ListaDeCentenas.Add(unidade);
                break;
        }
    }

    private string PopularUnidadeMilhar(int i, int numero)
    {
        return $" {((numero == 1) ? MILHAR_SINGULAR[QuantidadeDeCentenas - i] : MILHAR_PLURAL[QuantidadeDeCentenas - i])}";
    }
}