using MetaCash.Models;

namespace MetaCash.Services;

public class ComissaoService
{
    public void ProcessarComissoes(List<Venda> vendas)
    {
        // Agrupa as vendas por vendedor para somar as comissões individuais
        var vendasPorVendedor = vendas.GroupBy(v => v.Vendedor);

        Console.WriteLine("--- Relatório de Comissões ---");
        
        foreach (var grupo in vendasPorVendedor)
        {
            decimal comissaoTotal = 0;

            foreach (var venda in grupo)
            {
                comissaoTotal += CalcularComissao(venda.Valor);
            }

            Console.WriteLine($"Vendedor: {grupo.Key} | Comissão Total: R$ {comissaoTotal:F2}");
        }
    }

    private decimal CalcularComissao(decimal valor)
    {
        if (valor < 100.00m)
            return 0;
        
        if (valor < 500.00m)
            return valor * 0.01m; // 1%
        
        return valor * 0.05m; // 5%
    }
}