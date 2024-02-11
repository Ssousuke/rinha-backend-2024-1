using RinhaBackend2024.DTO.Comum;
using RinhaBackend2024.DTO.Request;
using RinhaBackend2024.DTO.Response;

namespace RinhaBackend2024.Repository;

public interface IClienteRepository
{
    Task<bool> BuscarCliente(int clienteId);
    Task<ClienteResponseDTO> CriarTransacao(TransacaoRequestDTO transacaoRequest, int id);
    Task<ExtratoDTO> BuscarUltimasTransacoes(int clienteId);
}