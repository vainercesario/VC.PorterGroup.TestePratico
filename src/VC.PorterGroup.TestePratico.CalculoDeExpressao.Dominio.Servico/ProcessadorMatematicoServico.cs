using Microsoft.Extensions.Logging;
using VC.PorterGroup.TestePratico.CalculoDeExpressao.Dominio.Interface;

namespace VC.PorterGroup.TestePratico.CalculoDeExpressao.Dominio.Servico;

internal sealed class ProcessadorMatematicoServico : IProcessadorMatematicoServico
{
    private readonly ILogger<ProcessadorMatematicoServico> _logger;

    public ProcessadorMatematicoServico(ILogger<ProcessadorMatematicoServico> logger)
    {
        this._logger = logger;
    }

    public decimal Calcular(string expressao)
    {
        _logger.LogInformation("Realizar cálculo de expressão string.");

        ExpressaoMatematica expressaoMatematica = new(expressao);

        var expressaoValida = expressaoMatematica.Validar();

        if (expressaoValida.Valido)
            return expressaoMatematica.Calcular();

        throw new ArgumentException(expressaoValida.Erro);
    }
}