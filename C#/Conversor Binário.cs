using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();

        while (true)
        {
            int escolha = menu.menuInicial();
            if (escolha == 0)
            {
                break;
            }
            switch (escolha)
            {
                case 1:
                    menu.menuDecimal();
                    break;
                case 2:
                    menu.menuOctal();
                    break;
                case 3:
                    menu.menuHexadecimal();
                    break;
                default:
                    Console.WriteLine("Escolha inválida. Digite apenas 1, 2, 3 ou 0 para sair.");
                    break;
            }
        }
    }
}

public class Menu
{
    public int menuInicial()
    {
        Console.WriteLine("======================================");
        Console.WriteLine("|        CALCULADORA DO PROG         |");
        Console.WriteLine("|                                    |");
        Console.WriteLine("| 0. Sair                            |");
        Console.WriteLine("| 1. Decimal para binário            |");
        Console.WriteLine("| 2. Octal para binário              |");
        Console.WriteLine("| 3. Hexadecimal para binário        |");
        Console.WriteLine("======================================");
        int escolha;
        do
        {
            Console.Write("Escolha uma opção: ");
        } while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 0 || escolha > 3);

        return escolha;
    }
    public void menuDecimal()
    {
        Console.WriteLine("======================================");
        Console.WriteLine("|        DECIMAL PARA BINÁRIO        |");
        Console.WriteLine("======================================");
        Console.Write("\nQual número decimal você deseja converter: ");
        if (!int.TryParse(Console.ReadLine(), out int numDecimal))
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro válido.");
            return;
        }
        string errorMessage = erro(numDecimal);
        if (!string.IsNullOrEmpty(errorMessage))
        {
            Console.WriteLine(errorMessage);
            return;
        }
        string binario = Convert.ToString(numDecimal, 2);
        Console.WriteLine($"Binário: {binario}");
    }
    public void menuOctal()
    {
        Console.WriteLine("======================================");
        Console.WriteLine("|         OCTAL PARA BINÁRIO         |");
        Console.WriteLine("======================================");
        Console.Write("\nQual número octal você deseja converter: ");
        if (!int.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.AllowLeadingSign | System.Globalization.NumberStyles.AllowLeadingWhite | System.Globalization.NumberStyles.AllowTrailingWhite, null, out int numOctal))
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número octal válido.");
            return;
        }
        string errorMessage = erro(numOctal);
        if (!string.IsNullOrEmpty(errorMessage))
        {
            Console.WriteLine(errorMessage);
            return;
        }
        string binario = Convert.ToString(numOctal, 2);
        Console.WriteLine($"Binário: {binario}");
    }
    public void menuHexadecimal()
    {
        Console.WriteLine("======================================");
        Console.WriteLine("|      HEXADECIMAL PARA BINÁRIO      |");
        Console.WriteLine("======================================");
        Console.Write("\nQual número hexadecimal você deseja converter: ");
        string? numHexadecimal = Console.ReadLine();
        int numDecimal;
        try
        {
            numDecimal = Convert.ToInt32(numHexadecimal, 16);
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número hexadecimal válido.");
            return;
        }
        string errorMessage = erro(numDecimal);
        if (!string.IsNullOrEmpty(errorMessage))
        {
            Console.WriteLine(errorMessage);
            return;
        }
        string binario = Convert.ToString(numDecimal, 2);
        Console.WriteLine($"Binário: {binario}");
    }
    public string erro(int numDecimal)
    {
        if (numDecimal > 127 || numDecimal < -127)
        {
            return "Observe se o número está no intervalo correto, para garantir no máximo 8 bits.";
        }
        else
        {
            return "";
        }
    }
}
