using Microsoft.AspNetCore.Mvc;
using VC.PorterGroup.TestePratico.SomaDeArray.Dominio.Servico;

namespace VC.PorterGroup.TestePratico.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SomaDeArrayController : ControllerBase
{
    private readonly ISomaArrayServico _somaArrayServico;

    public SomaDeArrayController(ISomaArrayServico somaArrayServico)
    {
        this._somaArrayServico = somaArrayServico;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] InteirosViewModel lista, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _somaArrayServico.SomarAsync(lista.Numeros, cancellationToken));
        }
        catch (OverflowException)
        {
            return BadRequest("Ocorreu erro ao processar a informação.");
        }
        catch (Exception)
        {
        }
        finally
        {
            GC.SuppressFinalize(this);
        }
    }
}

public class InteirosViewModel
{
    public List<int> Numeros { get; set; }
}