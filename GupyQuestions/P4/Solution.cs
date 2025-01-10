using System.Text.Json;

namespace TargetSistemas.P4;

using static Utils;

public class Solution
{
    public static void main(string[] args)
    {
        ConsoleTitle("Resolução para o problema 4");
        foreach (var (estado, percentual) in P4())
            Console.WriteLine($"{estado}: {percentual}%");
    }
    
    // 4) Dado o valor de faturamento mensal de uma distribuidora, detalhado por estado:
    // • SP – R$67.836,43
    // • RJ – R$36.678,66
    // • MG – R$29.229,88
    // • ES – R$27.165,48
    // • Outros – R$19.849,53
    //
    // Escreva um programa na linguagem que desejar onde calcule o percentual de representação que cada estado teve dentro do valor total mensal da distribuidora.  
    static Dictionary<string, decimal> P4()
    {
        string jsonString = File.ReadAllText("faturamentoPorEstado.json");
        var jsonDocument = JsonDocument.Parse(jsonString);
        var faturamento = jsonDocument.RootElement.GetProperty("2024").GetProperty("dezembro");
        decimal total = faturamento.EnumerateObject().Sum(e => decimal.Parse(e.Value.GetString().Replace("R$ ", "")));
        
        return faturamento.EnumerateObject().ToDictionary(
            e => e.Name, 
            e => (decimal.Parse(e.Value.GetString().Replace("R$ ", "")) / total) * 100);
    }
}