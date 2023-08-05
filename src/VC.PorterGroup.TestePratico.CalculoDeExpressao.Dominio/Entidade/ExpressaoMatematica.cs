using System.Data;
using VC.PorterGroup.TestePratico.Infra.Core.Util.Extensao;

namespace VC.PorterGroup.TestePratico.CalculoDeExpressao.Dominio.Entidade;

public class ExpressaoMatematica
{
    public ExpressaoMatematica(string expressao)
    {
        Expressao = expressao.RemoverEspacos();
    }

    public string Expressao { get; private set; }

    public (bool Valido, List<string> Erro) Validar()
    {
        List<string> erros = new();

        if (Expressao.PossuiOperadorMatematicoSequencial()
            || Expressao.PossuiOperadorMatematicoAoInicio()
            || Expressao.PossuiOperadorMatematicoAoFinal())
        {
            erros.Add($"A expressão é inválida.");
        }

        if (Expressao.PossuiOperadorMatematicoDivisaoPorZero())
        {
            erros.Add($"Não é possível realizar divisão por zero.");
        }

        if (Expressao.EmBranco())
        {
            erros.Add($"Não existem dados para calcular.");
        }

        if (!erros.Any())
        {
            return (false, erros);
        }

        return (true, null);
    }

    public double Calcular()
    {
        DataTable dt = new();
        DataColumn dc = new("Expressao", typeof(string), Expressao);
        dt.Columns.Add(dc);
        dt.Rows.Add(0);

        return Convert.ToDouble((int)dt.Rows[0]["Expressao"]);
    }
}