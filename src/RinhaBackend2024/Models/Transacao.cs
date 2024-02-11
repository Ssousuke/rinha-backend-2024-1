using RinhaBackend2024.Models.AuxModel;

namespace RinhaBackend2024.Models;

public sealed class Transacao : BaseModel
{
    public int ClienteId { get; set; }
    public int Valor { get; set; }
    public DebitoCredito Tipo { get; set; }
    public string Descricao { get; set; }
    public DateTime RealizadaEm { get; set; }
}