﻿using System.Text.Json.Serialization;
using RinhaBackend2024.Models;
using RinhaBackend2024.Models.AuxModel;

namespace RinhaBackend2024.DTO.Request;

public class TransacaoRequestDTO : BaseModel
{
    [JsonPropertyName("valor")] public int Valor { get; set; }

    [JsonPropertyName("tipo")] public DebitoCredito Tipo { get; set; }

    [JsonPropertyName("descricao")] public string Descricao { get; set; }
}