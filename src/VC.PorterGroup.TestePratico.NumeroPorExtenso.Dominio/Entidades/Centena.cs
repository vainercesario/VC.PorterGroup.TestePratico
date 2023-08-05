using VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Base;

namespace VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Entidades;

public class Centena : NumeralDecorador
{
    private static readonly string[] CENTENAS = { "cem", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };

    public Centena(NumeralComponente numeral) : base(numeral)
    {
    }

    public override string EscreverPorExtenso()
    {
        if (Centena == 100)
            return $"{CENTENAS[0]}";

        return $"{CENTENAS[Centena]}{base.EscreverPorExtenso()}";
    }
}