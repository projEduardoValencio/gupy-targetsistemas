using System.Text.Json;

namespace TargetSistemas.P5;

using static Utils;

public class Solution
{
    public static void main(string[] args)
    {
        ConsoleTitle("Resolução para o problema 5");
        Console.Write("Inserir um texto para ser invertido: ");
        String textEnter = Console.ReadLine() ?? "";
        Console.WriteLine($"Texto invertido {P5(textEnter)}");
    }
    
    // 5) Escreva um programa que inverta os caracteres de um string.
    //
    // IMPORTANTE:
    // a) Essa string pode ser informada através de qualquer entrada de sua preferência ou pode ser previamente definida no código;
    // b) Evite usar funções prontas, como, por exemplo, reverse;
    static string P5(string text)
    {
        char[] textArray = text.ToCharArray();
        char[] reversedText = new char[textArray.Length];
        for(int i = 0; i < textArray.Length; i++)
        {
            reversedText[i] = textArray[textArray.Length - i - 1];
        }
        return new string(reversedText);
    }
}