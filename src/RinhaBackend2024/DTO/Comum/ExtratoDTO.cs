using RinhaBackend2024.DTO.Response;
using RinhaBackend2024.Models;
using System.Text.Json.Serialization;

namespace RinhaBackend2024.DTO.Comum;

public class ExtratoDTO : BaseModel
{
    [JsonPropertyName("saldo")]
    public SaldoDTO Saldo { get; set; }

    [JsonPropertyName("ultimas_transacoes")]
    public List<TransacaoResponseDTO> UltimasTransacoes { get; set; }
}