using Microsoft.AspNetCore.Mvc;
using RinhaBackend2024.DTO.Request;
using RinhaBackend2024.Repository;

namespace RinhaBackend2024.Controllers;

[ApiController]
[Route("clientes")]
public class ClienteController : ControllerBase
{
    private readonly IClienteRepository _repository;

    public ClienteController(IClienteRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("{id}/{transacao}")]
    public async Task<IActionResult> CriarTransacao([FromBody] TransacaoRequestDTO transacaoDto, int id)
    {
        var cliente = await _repository.BuscarCliente(id);
        if (cliente)
        {
            var transacao = await _repository.CriarTransacao(transacaoDto, id);
            if (transacao.Id != null)
                return Ok(transacao);
            return UnprocessableEntity();
        }

        return NotFound();
    }

    [HttpGet("{id}/extrato")]
    public async Task<IActionResult> BuscarExtrato(int id)
    {
        var extrato = await _repository.BuscarUltimasTransacoes(id);
        var cliente = await _repository.BuscarCliente(id);

        if (!cliente)
            return NotFound();

        return Ok(extrato);
    }
}