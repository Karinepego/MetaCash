using System.Text.Json.Serialization;

namespace MetaCash.Models;

public class Produto
{
    [JsonPropertyName("codigoProduto")]
    public int CodigoProduto { get; set; }

    [JsonPropertyName("descricaoProduto")]
    public string DescricaoProduto { get; set; } = string.Empty;

    [JsonPropertyName("estoque")]
    public int EstoqueAtual { get; set; }
}

public class EstoqueRoot
{
    [JsonPropertyName("estoque")]
    public List<Produto> Produtos { get; set; } = new();
}