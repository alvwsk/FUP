using System;
internal class Program
{
    private static void Main(string[] args)
    {
        Nota aluno = new Nota();
        aluno.Iniciar();
        Console.ReadLine();
    }
}
public class Nota
{
    private double Soma { get; set; } = 0.0;
    private int Quantidade_De_Notas { get; set; } = 0;

    public void Iniciar()
    {
        try
        {
            Quantidade_De_Notas = LerQuantidadeDeNotas();
            SomandoNotas();
            Console.WriteLine(AnalisaMedia());
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Insira um valor numérico válido.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Erro: O valor inserido é muito grande.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }

    private int LerQuantidadeDeNotas()
    {
        Console.Write("Quantas notas você deseja adicionar: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    private double LerNota(int numeroNota)
    {
        Console.Write($"Informe a {numeroNota}ª nota: ");
        return Convert.ToDouble(Console.ReadLine());
    }

    private void SomandoNotas()
    {
        for (int i = 1; i <= Quantidade_De_Notas; i++)
        {
            Soma += LerNota(i);
        }
    }

    private string AnalisaMedia()
    {
        if (Quantidade_De_Notas == 0)
        {
            return "Sem notas para analisar";
        }

        double media = Soma / Quantidade_De_Notas;
        return media >= 7 ? "Aprovado" : "Reprovado";
    }
}
