using VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Base;

namespace VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Entidades;

public class Unidade : NumeralComponente
{
    private static readonly string[] UNIDADES = { "", "Um", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove" };

    public Unidade(int numero)
        : base(numero) { }

    public override string EscreverPorExtenso()
    {
        if (Dezena == 1)
            return "";

        return $"{((Unidade > 0 && (Dezena > 1 || (Centena > 0 && Dezena == 0))) ? " e " : "")}{UNIDADES[Unidade]}";
    }
}