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
    public IActionResult Get([FromBody] decimal numero)
    {
        return Ok(_montarNumeroService.GerarNumeroPorExtenso(numero));
    }
}