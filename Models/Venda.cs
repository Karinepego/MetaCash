using System.Text.Json.Serialization;

namespace MetaCash.Models;

public class Venda
{
    [JsonPropertyName("vendedor")]
    public string Vendedor { get; set; } = string.Empty;

    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }
}

public class VendaRoot
{
    [JsonPropertyName("vendas")]
    public List<Venda> Vendas { get; set; } = new();
}