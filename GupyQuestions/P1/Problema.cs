namespace TargetSistemas.P1;

using static Utils;

public class Problema
{
    static void main(string[] args)
    {
        ConsoleTitle("Resolução para o problema 1");
        Console.WriteLine(P1());
        Console.WriteLine("Hello, World!");
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
}
