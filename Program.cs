using System.Text.Json;
using MetaCash.Models;
using MetaCash.Services;

namespace MetaCash;

class Program
{
    static void Main(string[] args)
    {
        // Caminho do arquivo JSON
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "vendas.json");

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Arquivo vendas.json não encontrado!");
            return;
        }

        // Lê e desserializa o JSON
        string jsonString = File.ReadAllText(filePath);
        var dados = JsonSerializer.Deserialize<VendaRoot>(jsonString);

        if (dados != null && dados.Vendas != null)
        {
            // Executa o serviço do Desafio 1
            var comissaoService = new ComissaoService();
            comissaoService.ProcessarComissoes(dados.Vendas);
        }
    }
}