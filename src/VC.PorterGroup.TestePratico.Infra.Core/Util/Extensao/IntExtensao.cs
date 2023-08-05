using VC.PorterGroup.TestePratico.Infra.Core.Util.Enum;

namespace VC.PorterGroup.TestePratico.Infra.Core.Util.Extensao;

public static class ConversorIntExtensao
{
    public static char[] ConverterParaChar(this int valor) => valor.ToString().ToCharArray();
}

public static class ModificadorIntExtensao
{
    public static byte RetornaByteDaPosicao(this int valor, CasasDeValores casa)
    {
        int totalPosicoes = valor.TotalItens();

        ValidarIntegridade(totalPosicoes, casa);

        return totalPosicoes switch
        {
            1 => (byte)valor,
            2 => ObterDezena(valor, casa),
            3 => ObterCentena(valor, casa),
            _ => 0,
        };
    }

    private static byte ObterDezena(int valor, CasasDeValores casa) => casa switch
    {
        CasasDeValores.Unidade => (byte)(valor % (int)CasasDeValores.Dezena),
        CasasDeValores.Dezena => (byte)(valor / (int)CasasDeValores.Dezena),
        _ => 0,
    };

    private static byte ObterCentena(int valor, CasasDeValores casa)
    {
        switch (casa)
        {
            case CasasDeValores.Unidade:
                var dezenasDaUnidade = (valor % (int)CasasDeValores.Centena);
                var unidades = (dezenasDaUnidade % (int)CasasDeValores.Dezena);

                return (byte)(unidades);

            case CasasDeValores.Dezena:
                var dezenas = (valor % (int)CasasDeValores.Centena);
                return (byte)(dezenas / (int)CasasDeValores.Dezena);

            case CasasDeValores.Centena:
                return (byte)(valor / (int)CasasDeValores.Centena);

            default:
                return 0;
        }
    }

    private static void ValidarIntegridade(int totalPosicoes, CasasDeValores casa)
    {
        const string TERMO_INCORRETO = "Número incorreto para captura da posição.";
        const string TERMO_SOLICITADO = "O número de checagem excedeu a casa da centena.";

        switch (totalPosicoes)
        {
            case 1:
                if (casa > CasasDeValores.Unidade)
                    throw new ArgumentOutOfRangeException(TERMO_SOLICITADO);

                break;

            case 2:
                if (casa > CasasDeValores.Dezena)
                    throw new ArgumentOutOfRangeException(TERMO_SOLICITADO);
                break;

            default:
                if (totalPosicoes > 3)
                    throw new ArgumentOutOfRangeException(TERMO_INCORRETO);

                break;
        }
    }
}

public static class ClassificadorIntExtensao
{
    public static CasasDeValores IdentificarCasaDeUnidade(this int valor) => valor.TotalItens() switch
    {
        1 => CasasDeValores.Unidade,
        2 => CasasDeValores.Dezena,
        3 => CasasDeValores.Centena,
        _ => throw new ArgumentOutOfRangeException("Item fora do escopo de definição.")
    };
}

public static class IntAuxiliares
{
    public static int TotalItens(this int valor)
    {
        char[] numeroEmTexto = valor.ConverterParaChar();
        return numeroEmTexto.Length;
    }
}