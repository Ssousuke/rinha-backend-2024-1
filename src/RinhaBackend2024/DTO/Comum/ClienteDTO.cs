using RinhaBackend2024.Models;

namespace RinhaBackend2024.DTO.Comum;

public class ClienteDTO : BaseModel
{
    public int ClientId { get; set; }
    public int Limite { get; set; }
    public int Saldo { get; set; }
}