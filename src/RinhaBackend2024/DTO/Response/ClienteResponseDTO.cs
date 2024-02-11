using System.Text.Json.Serialization;
using RinhaBackend2024.Models;

namespace RinhaBackend2024.DTO.Response;

public class ClienteResponseDTO : BaseModel
{
    [JsonPropertyName("limite")] public int Limite { get; set; }

    [JsonPropertyName("saldo")] public int Saldo { get; set; }
}