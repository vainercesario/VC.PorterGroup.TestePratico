using Microsoft.AspNetCore.Mvc;
using VC.PorterGroup.TestePratico.ObjetosUnicos.Dominio.Servico;
using VC.PorterGroup.TestePratico.ViewModel;

namespace VC.PorterGroup.TestePratico.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ObjetosUnicosController : ControllerBase
{
    private readonly IObjetosUnicosServico<object> _objetosUnicosServico;

    public ObjetosUnicosController(IObjetosUnicosServico<object> objetosUnicosServico)
    {
        this._objetosUnicosServico = objetosUnicosServico;
    }

    [HttpPost]
    public IActionResult Post([FromBody] ArrayDeObjetosViewModel<object> lista)
    {
        try
        {
            return Ok(_objetosUnicosServico.RemoverRedundancias(lista.Dados));
        }
        catch
        {
            return BadRequest("Não foi possível realizar a operação.");
        }
    }
}