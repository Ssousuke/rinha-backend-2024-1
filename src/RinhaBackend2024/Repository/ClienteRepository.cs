using Microsoft.EntityFrameworkCore;
using RinhaBackend2024.Context;
using RinhaBackend2024.DTO.Comum;
using RinhaBackend2024.DTO.Request;
using RinhaBackend2024.DTO.Response;
using RinhaBackend2024.Models;

namespace RinhaBackend2024.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _dbContext;

    public ClienteRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ClienteResponseDTO> CriarTransacao(TransacaoRequestDTO transacaoRequest, int id)
    {
        var cliente = await _dbContext.Clientes.SingleAsync(x => x.ClientId == id);
        var transacao = new Transacao
        {
            ClienteId = id,
            Valor = transacaoRequest.Valor,
            Tipo = transacaoRequest.Tipo,
            Descricao = transacaoRequest.Descricao,
            RealizadaEm = DateTime.Now
        };

        var clienteDTO = new ClienteDTO
        {
            ClientId = cliente.ClientId,
            Limite = cliente.Limite,
            Saldo = cliente.Saldo
        };
        AtualizarSaldo(clienteDTO, transacao.Valor, transacao.Tipo.ToString());

        await _dbContext.Transacoes.AddAsync(transacao);
        await _dbContext.SaveChangesAsync();

        return new ClienteResponseDTO
        {
            Limite = cliente.Limite,
            Saldo = cliente.Saldo
        };
    }

    public async Task<ExtratoDTO> BuscarUltimasTransacoes(int clienteId)
    {
        var transacoes = await _dbContext.Transacoes
            .Where(x => x.ClienteId == clienteId)
            .ToListAsync();

        var cliente = await _dbContext.Clientes.SingleAsync(x => x.ClientId == clienteId);

        var transacoesDTO = transacoes.Select(t => new TransacaoResponseDTO
        {
            Valor = t.Valor,
            Tipo = t.Tipo,
            Descricao = t.Descricao,
            RealizadaEm = t.RealizadaEm
        }).ToList();

        var saldoDTO = new SaldoDTO
        {
            Total = cliente.Saldo,
            Limite = cliente.Limite,
            DataExtrato = DateTime.Now
        };

        var extratoDTO = new ExtratoDTO
        {
            Saldo = saldoDTO,
            UltimasTransacoes = transacoesDTO
        };

        return extratoDTO;
    }

    public async Task<bool> BuscarCliente(int clienteId)
    {
        var cliente = await _dbContext.Clientes.SingleAsync(x => x.ClientId == clienteId);
        return cliente == null ? true : false;
    }

    private async void AtualizarSaldo(ClienteDTO cliente, int valor, string tipo)
    {
        var buscaCliente = await _dbContext.Clientes.SingleAsync(x => x.ClientId == cliente.ClientId);
        buscaCliente.Limite = cliente.Limite;

        if (tipo.Equals('d'))
            buscaCliente.Saldo -= valor;
        else
            buscaCliente.Saldo += valor;

        _dbContext.Update(buscaCliente);
        await _dbContext.SaveChangesAsync();
    }
}