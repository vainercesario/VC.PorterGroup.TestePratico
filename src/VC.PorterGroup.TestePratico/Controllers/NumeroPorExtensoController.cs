using Microsoft.AspNetCore.Mvc;
using VC.PorterGroup.TestePratico.NumeroPorExtenso.Dominio.Interface;

namespace VC.PorterGroup.TestePratico.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NumeroPorExtensoController : ControllerBase
{
    private readonly IMontarNumeroPorExtensoService _montarNumeroService;

    public NumeroPorExtensoController(IMontarNumeroPorExtensoService montarNumeroService)
    {
        this._montarNumeroService = montarNumeroService;
    }

    [HttpGet]
    public IActionResult Get(decimal numero)
    {
        try
        {
            return Ok(_montarNumeroService.GerarNumeroPorExtenso(numero));
        }
        catch
        {
            return BadRequest("O dado enviado está fora do padrão para conversão. Informe um número sem casas decimais.");
        }
    }
}