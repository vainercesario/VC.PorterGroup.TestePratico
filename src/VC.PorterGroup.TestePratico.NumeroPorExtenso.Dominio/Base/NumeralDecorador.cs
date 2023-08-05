namespace VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Base;

public abstract class NumeralDecorador : NumeralComponente
{
    private readonly NumeralComponente numeral;

    protected NumeralDecorador(NumeralComponente numeral)
        : base(numeral.Numero)
    {
        this.numeral = numeral;
    }

    public override string EscreverPorExtenso()
    {
        if (numeral != null)
        {
            return numeral.EscreverPorExtenso();
        }
        else
        {
            return string.Empty;
        }
    }
}