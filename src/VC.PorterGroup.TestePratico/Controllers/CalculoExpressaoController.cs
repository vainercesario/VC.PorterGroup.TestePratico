using Microsoft.AspNetCore.Mvc;
using VC.PorterGroup.TestePratico.CalculoDeExpressao.Dominio.Interface;

namespace VC.PorterGroup.TestePratico.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalculoExpressaoController : ControllerBase
{
    private readonly IProcessadorMatematicoServico _processadorMatematicoServico;

    public CalculoExpressaoController(IProcessadorMatematicoServico processadorMatematicoServico)
    {
        this._processadorMatematicoServico = processadorMatematicoServico;
    }

    [HttpGet]
    public IActionResult Get(string expressao)
    {
        try
        {
            return Ok(_processadorMatematicoServico.Calcular(expressao));
        }
        catch (Exception ex)
        {
            return BadRequest($"Não foi possível realizar a operação: {ex.Message}");
        }
    }
}