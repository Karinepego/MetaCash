using System.Text.Json;
using MetaCash.Models;
using MetaCash.Services;

namespace MetaCash;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== SISTEMA METACASH ===\n");

        Comissoes();
        Estoque();
        Juros(); // Nova chamada
    }

    static void Comissoes()
    {
        Console.WriteLine("--- COMISSÕES ---");
        string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "vendas.json");
        var dados = JsonSerializer.Deserialize<VendaRoot>(File.ReadAllText(path));

        if (dados != null)
        {
            new ComissaoService().ProcessarComissoes(dados.Vendas);
        }
        Console.WriteLine("\n");
    }

    static void Estoque()
    {
        Console.WriteLine("--- MOVIMENTAÇÃO DE ESTOQUE ---");
        string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "estoque.json");
        var dados = JsonSerializer.Deserialize<EstoqueRoot>(File.ReadAllText(path));

        if (dados != null)
        {
            var estoqueService = new EstoqueService();

            estoqueService.RegistrarMovimentacao(dados.Produtos, 101, "Compra de suprimentos", 50, isEntrada: true);
            estoqueService.RegistrarMovimentacao(dados.Produtos, 102, "Venda para cliente X", 20, isEntrada: false);
            estoqueService.RegistrarMovimentacao(dados.Produtos, 105, "Venda para cliente Y", 100, isEntrada: false);
        }
        Console.WriteLine("\n");
    }

    static void Juros()
    {
        Console.WriteLine("--- CÁLCULO DE JUROS ---");
        var jurosService = new JurosService();
        
        // Simulação 1: Boleto vencido há 10 dias
        jurosService.CalcularJuros(1000.00m, DateTime.Today.AddDays(-10));
        
        // Simulação 2: Boleto em dia (vence amanhã)
        jurosService.CalcularJuros(1500.50m, DateTime.Today.AddDays(1));
    }
}