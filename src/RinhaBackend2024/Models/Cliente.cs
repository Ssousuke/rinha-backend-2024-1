namespace RinhaBackend2024.Models;

public sealed class Cliente : BaseModel
{
    public int ClientId { get; set; }
    public int Limite { get; set; }
    public int Saldo { get; set; }
}