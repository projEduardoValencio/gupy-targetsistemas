using System.Text.Json;

namespace TargetSistemas;

public static class Q2
{
    static void Main(string[] args)
    {
        ConsoleTitle("Resolução para o problema 1");
        Console.WriteLine(P1());
        
        ConsoleTitle("Resolução para o problema 2");
        Console.Write("Inserir um valor para ser analisado: ");
        int targetNumber = int.Parse(Console.Read());
        Console.WriteLine(P2(targetNumber) ? "O número informado pertence a sequência de Fibonacci." : "O número informado não pertence a sequência de Fibonacci.");
        
        
    }

    // 1) Observe o trecho de código abaixo: int INDICE = 13, SOMA = 0, K = 0;
    // Enquanto K < INDICE faça { K = K + 1; SOMA = SOMA + K; }
    // Imprimir(SOMA);
    // Ao final do processamento, qual será o valor da variável SOMA?
    static int P1()
    {
        int INDICE = 13, SOMA = 0, K = 0;
        
        while (K < INDICE)
        {
            K++;
            SOMA += K;
        }

        return SOMA;
    }
    
    // 2) Dado a sequência de Fibonacci, onde se inicia por 0 e 1 e o próximo valor sempre será a soma dos 2 valores anteriores (exemplo: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34...), escreva um programa na linguagem que desejar onde, informado um número, ele calcule a sequência de Fibonacci e retorne uma mensagem avisando se o número informado pertence ou não a sequência.
    //
    // IMPORTANTE: Esse número pode ser informado através de qualquer entrada de sua preferência ou pode ser previamente definido no código;
    static bool P2(int targetNumber, int previousNumber = 0, int currentNumber = 1)
    {
        if (currentNumber < targetNumber)
            return P2(targetNumber, currentNumber, previousNumber + currentNumber);
        return currentNumber == targetNumber;
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
    static (decimal min, decimal max, decimal med, int dayCount) P3()
    {
        string jsonString = File.ReadAllText("GupyQuestions/faturamentoMensal.json");
        var jsonDocument = JsonDocument.Parse(jsonString);
        var faturamento = jsonDocument.RootElement.GetProperty("2024").GetProperty("dezembro").EnumerateArray().Select(e => decimal.Parse(e.GetString().Replace("R$ ", ""))).ToArray();
        
        decimal min = faturamento.Min();
        decimal max = faturamento.Max();
        decimal med = faturamento.Average();
        int dayCount = faturamento.Count(e => e > med);

        return (min, max, med, dayCount);
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
    
    // 5) Escreva um programa que inverta os caracteres de um string.
    //
    // IMPORTANTE:
    // a) Essa string pode ser informada através de qualquer entrada de sua preferência ou pode ser previamente definida no código;
    // b) Evite usar funções prontas, como, por exemplo, reverse;
    static string P5(string text)
    {
        char[] textArray = text.ToCharArray();
        char[] reversedText = new char[array.Length];
        for(int i = 0; i < textArray.Length; i++)
        {
            reversedText[i] = textArray[textArray.Length - i - 1];
        }
        return new string(reversedText);
    }


}