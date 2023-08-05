﻿using Microsoft.AspNetCore.Mvc;
using VC.PorterGroup.TestePratico.SomaDeArray.Dominio.Servico;
using VC.PorterGroup.TestePratico.ViewModel;

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
    public async Task<IActionResult> Post([FromBody] ArrayDeIntViewModel lista, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _somaArrayServico.SomarAsync(lista.Numeros, cancellationToken));
        }
        catch (OverflowException)
        {
            return BadRequest("O somatório resultou em um valor não suportado de retorno, tente reduzir o tamanho solicitado.");
        }
        catch (Exception)
        {
            return BadRequest("Ocorreu erro ao processar a informação.");
        }
        finally
        {
            GC.SuppressFinalize(this);
        }
    }
}