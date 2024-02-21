using RinhaBackend2024.Models;
using RinhaBackend2024.Models.AuxModel;
using System.Text.Json.Serialization;

namespace RinhaBackend2024.DTO.Response;

public class TransacaoResponseDTO : BaseModel
{
    [JsonPropertyName("valor")] public int Valor { get; set; }
    [JsonPropertyName("tipo")] public DebitoCredito Tipo { get; set; }
    [JsonPropertyName("descricao")] public string Descricao { get; set; }
    [JsonPropertyName("realizada_em")] public DateTime RealizadaEm { get; set; }
}