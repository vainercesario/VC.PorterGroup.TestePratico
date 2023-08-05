using VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Base;

namespace VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Entidades;

public class Dezena : NumeralDecorador
{
    private static readonly string[] DEZENAS_INICIAIS = { "Dez", "Onze", "Doze", "Treze", "Catorze", "Quinze", "Dezesseis", "Dezessete", "Dezoito", "Dezenove" };
    private static readonly string[] DEZENAS = { "", "", "Vinte", "Trinta", "Quarenta", "Cinquenta", "Sessenta", "Setenta", "Oitenta", "Noventa" };

    public Dezena(NumeralComponente numeral)
        : base(numeral)
    {
    }

    public override string EscreverPorExtenso()
    {
        if (Dezena == 0)
        {
            return $"{base.EscreverPorExtenso()}";
        }

        if (Dezena == 1)
        {
            return $"{((Centena > 0 && Numero != 100) ? " e " : "")}{DEZENAS_INICIAIS[Unidade]}";
        }

        return $"{((Centena > 0 && Numero != 100) ? " e " : "")}{DEZENAS[Dezena]}{base.EscreverPorExtenso()}";
    }
}