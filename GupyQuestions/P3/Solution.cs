using System.Text.Json;

namespace TargetSistemas.P3;

using static Utils;

public class Solution
{
    public static void main(string[] args)
    {
        string jsonString = File.ReadAllText("GupyQuestions/faturamentoMensal.json");
        var jsonDocument = JsonDocument.Parse(jsonString);
        var faturamento = jsonDocument.RootElement.GetProperty("2024").GetProperty("dezembro").EnumerateArray().Select(e => decimal.Parse(e.GetString().Replace("R$ ", ""))).ToArray();
        
        decimal min, max, med;
        int daysAboveAverage;
        (min, max, med, daysAboveAverage) = P3(faturamento);

        ConsoleTitle("Resolução para o problema 3");
        Console.WriteLine($"Menor valor de faturamento: {min}");
        Console.WriteLine($"Maior valor de faturamento: {max}");
        Console.WriteLine($"Valor médio de faturamento diário: {med}");
        Console.WriteLine($"Número de dias com faturamento superior à média: {daysAboveAverage}");
    }
    
    // 3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, que calcule e retorne:
    // • O menor valor de faturamento ocorrido em um dia do mês;
    // • O maior valor de faturamento ocorrido em um dia do mês;
    // • Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.
    //
    //     IMPORTANTE:
    // a) Usar o json ou xml disponível como fonte dos dados do faturamento mensal;
    // b) Podem existir dias sem faturamento, como nos finais de semana e feriados. Estes dias devem ser ignorados no cálculo da média;
    
    // Considerando que finais de semana e feriados são ignorados, não é possível calcular a média mensal.
    static (decimal min, decimal max, decimal med, int daysAboveAverage) P3(decimal[] faturamento)
    {
        
        decimal min = faturamento.Min();
        decimal max = faturamento.Max();
        decimal med = faturamento.Average();
        int daysAboveAverage = faturamento.Count(e => e > med);

        return (min, max, med, daysAboveAverage);
    }
}