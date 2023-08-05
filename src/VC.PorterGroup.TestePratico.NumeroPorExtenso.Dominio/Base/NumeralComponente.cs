using VC.PorterGroup.TestePratico.Infra.Core.Util.Enum;
using VC.PorterGroup.TestePratico.Infra.Core.Util.Extensao;

namespace VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Base;

public abstract class NumeralComponente
{
    public NumeralComponente(int numero)
    {
        Numero = numero;

        Unidade = Numero.RetornaByteDaPosicao(CasasDeValores.Unidade);
        Dezena = (byte)((Numero.TotalItens() >= 2) ? Numero.RetornaByteDaPosicao(CasasDeValores.Dezena) : 0);
        Centena = (byte)((Numero.TotalItens() == 3) ? Numero.RetornaByteDaPosicao(CasasDeValores.Centena) : 0);
    }

    public int Numero { get; private set; }
    public byte Unidade { get; private set; }
    public byte Dezena { get; private set; }
    public byte Centena { get; private set; }

    public abstract string EscreverPorExtenso();
}