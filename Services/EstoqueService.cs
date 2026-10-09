using MetaCash.Models;

namespace MetaCash.Services;

public class EstoqueService
{
    public void RegistrarMovimentacao(List<Produto> estoque, int codigoProduto, string descricao, int quantidade, bool isEntrada)
    {
        var produto = estoque.FirstOrDefault(p => p.CodigoProduto == codigoProduto);
        
        if (produto == null)
        {
            Console.WriteLine($"Produto código {codigoProduto} não encontrado.");
            return;
        }

        // Gera um ID único para a movimentação (usando Guid para garantir unicidade)
        string idMovimentacao = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        string tipo = isEntrada ? "ENTRADA" : "SAÍDA";

        // Regra de negócio: não permitir saída maior que o estoque atual
        if (!isEntrada && produto.EstoqueAtual < quantidade)
        {
            Console.WriteLine($"[ID: {idMovimentacao}] ERRO: Saldo insuficiente para {produto.DescricaoProduto}. Tentativa: {quantidade}, Disponível: {produto.EstoqueAtual}");
            Console.WriteLine("--------------------------------------------------");
            return;
        }

        // Aplica a movimentação
        produto.EstoqueAtual += isEntrada ? quantidade : -quantidade;

        Console.WriteLine($"[ID: {idMovimentacao}] {tipo} - Descrição: {descricao}");
        Console.WriteLine($"Produto: {produto.DescricaoProduto} | Nova Qtde Final: {produto.EstoqueAtual}");
        Console.WriteLine("--------------------------------------------------");
    }
}