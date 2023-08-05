using Microsoft.Extensions.Logging;
using VC.PorterGroup.TestePratico.CalculoDeExpressao.Dominio.Entidade;
using VC.PorterGroup.TestePratico.CalculoDeExpressao.Dominio.Interface;
using VC.PorterGroup.TestePratico.Infra.Core.Util.Extensao;

namespace VC.PorterGroup.TestePratico.CalculoDeExpressao.Dominio.Servico;

internal sealed class ProcessadorMatematicoServico : IProcessadorMatematicoServico
{
    private readonly ILogger<ProcessadorMatematicoServico> _logger;

    public ProcessadorMatematicoServico(ILogger<ProcessadorMatematicoServico> logger)
    {
        this._logger = logger;
    }

    public double Calcular(string expressao)
    {
        _logger.LogInformation("Realizar cálculo de expressão string.");

        ExpressaoMatematica expressaoMatematica = new(expressao);

        (bool valido, List<string> erro) = expressaoMatematica.Validar();

        if (valido)
        {
            return expressaoMatematica.Calcular();
        }

        throw new ArithmeticException(erro.Unificado(". "));
    }
}