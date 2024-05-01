using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Pessoa.Iniciar();

        Console.ReadKey();
    }
}

public class Pessoa
{
    private static readonly Random random = new Random();
    private static readonly Dictionary<int, string> pessoas = new Dictionary<int, string>();

    public static void Exibir()
    {
        Console.WriteLine("ID\tNOME");
        foreach (var pessoa in pessoas.OrderBy(item => item.Key))
        {
            Console.WriteLine($"{pessoa.Key}\t{pessoa.Value}");
        }
    }

    public static void AdicionarPessoa(int id, string nome)
    {
        pessoas.Add(id, nome);
    }

    public static void Iniciar()
    {
        Console.WriteLine("Quantos nomes deseja cadastrar? ");
        int num;
        while (!int.TryParse(Console.ReadLine(), out num) || num <= 0)
        {
            Console.WriteLine("Por favor, insira um número inteiro positivo.");
        }

        string nome;
        for (int i = 1; i <= num; i++)
        {
            int id;
            do
            {
                id = random.Next(1, int.MaxValue);
            } while (pessoas.ContainsKey(id));

            bool nomeInvalido;
            do
            {
                Console.Write("Digite o nome: ");
                nome = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("Nome não pode estar em branco.");
                    nomeInvalido = true;
                }
                else if (ContemApenasNumeros(nome))
                {
                    Console.WriteLine("O nome não pode consistir apenas de números. Por favor, insira um nome válido.");
                    nomeInvalido = true;
                }
                else
                {
                    nomeInvalido = false;
                    AdicionarPessoa(id, nome);
                }
            } while (nomeInvalido);
        }
        Exibir();
    }

    public static bool ContemApenasNumeros(string nome)
    {
        foreach (char letra in nome)
        {
            if (!char.IsDigit(letra))
            {
                return false;
            }
        }
        return true;
    }
}
