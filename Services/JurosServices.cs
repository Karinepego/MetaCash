namespace MetaCash.Services;

public class JurosService
{
    public void CalcularJuros(decimal valorOriginal, DateTime dataVencimento)
    {
        DateTime dataAtual = DateTime.Today;
        
        Console.WriteLine($"Valor Original: R$ {valorOriginal:F2} | Vencimento: {dataVencimento:dd/MM/yyyy}");

        if (dataAtual <= dataVencimento)
        {
            Console.WriteLine("Status: Em dia. Nenhum juros aplicado.");
            Console.WriteLine($"Valor a pagar: R$ {valorOriginal:F2}");
            Console.WriteLine("--------------------------------------------------");
            return;
        }

        int diasAtraso = (dataAtual - dataVencimento).Days;
        decimal taxaAoDia = 0.025m; // 2,5% ao dia = 0.025
        
        decimal valorJuros = valorOriginal * taxaAoDia * diasAtraso;
        decimal valorTotal = valorOriginal + valorJuros;

        Console.WriteLine($"Dias de atraso: {diasAtraso}");
        Console.WriteLine($"Juros acumulado (2,5% ao dia): R$ {valorJuros:F2}");
        Console.WriteLine($"Valor total a pagar: R$ {valorTotal:F2}");
        Console.WriteLine("--------------------------------------------------");
    }
}