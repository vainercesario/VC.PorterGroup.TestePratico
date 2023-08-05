using VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Base;

namespace VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Entidades;

public class Centena : NumeralDecorador
{
    private static readonly string[] CENTENAS = { "Cem", "Cento", "Duzentos", "Trezentos", "Quatrocentos", "Quinhentos", "Seiscentos", "Setecentos", "Oitocentos", "Novecentos" };

    public Centena(NumeralComponente numeral) : base(numeral)
    {
    }

    public override string EscreverPorExtenso()
    {
        if (Numero == 100)
            return $"{CENTENAS[0]}";

        return $"{CENTENAS[Centena]}{base.EscreverPorExtenso()}";
    }
}