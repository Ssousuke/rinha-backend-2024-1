using RinhaBackend2024.Models;
using System.Text.Json.Serialization;

namespace RinhaBackend2024.DTO.Comum;

public class SaldoDTO : BaseModel
{
    [JsonPropertyName("total")] public int Total { get; set; }

    [JsonPropertyName("limite")] public int Limite { get; set; }

    [JsonPropertyName("data_extrato")] public DateTime DataExtrato { get; set; }
}