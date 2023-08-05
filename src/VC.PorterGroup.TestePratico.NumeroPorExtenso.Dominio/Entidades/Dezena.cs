using VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Base;

namespace VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Entidades;

public class Dezena : NumeralDecorador
{
    private static readonly string[] DEZENAS_INICIAIS = { "dez", "onze", "doze", "treze", "catorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
    private static readonly string[] DEZENAS = { "", "", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };

    public Dezena(NumeralComponente numeral)
        : base(numeral)
    {
    }

    public override string EscreverPorExtenso()
    {
        if (Dezena == 0)
            return $"{base.EscreverPorExtenso()}";

        if (Dezena == 1)
            return $"{((Centena > 0 && Numero != 100) ? " e " : "")}{DEZENAS_INICIAIS[Unidade]}";

        return $"{((Centena > 0 && Numero != 100) ? " e " : "")}{DEZENAS[Dezena]}{base.EscreverPorExtenso()}";
    }
}