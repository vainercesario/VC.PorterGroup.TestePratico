using System.Text.RegularExpressions;

namespace VC.PorterGroup.TestePratico.Infra.Core.Util.Extensao;

public static class StringExtensao
{
    public static string RemoverEspacos(this string texto)
    {
        if (texto is null)
            return "";

        return texto.Replace(" ", "");
    }

    public static string Unificado(this List<string> lista, string separador)
    {
        return string.Join(separador, lista);
    }

    public static bool EmBranco(this string texto)
    {
        return string.IsNullOrWhiteSpace(texto);
    }
}

public static class OperadoresMatematicosStringExtensao
{
    public static bool PossuiOperadorMatematicoSequencial(this string valor)
    {
        string expressao = @"(?:[+\-*/^]{2,})";
        return Regex.IsMatch(valor, expressao);
    }

    public static bool PossuiOperadorMatematicoAoInicio(this string valor)
    {
        string expressao = @"^[+\*/]";
        return Regex.IsMatch(valor, expressao);
    }

    public static bool PossuiOperadorMatematicoAoFinal(this string valor)
    {
        string expressao = @"[+\-*/]$";
        return Regex.IsMatch(valor, expressao);
    }

    public static bool PossuiOperadorMatematicoDivisaoPorZero(this string valor)
    {
        string expressao = @"\/0"; ;
        return Regex.IsMatch(valor, expressao);
    }
}