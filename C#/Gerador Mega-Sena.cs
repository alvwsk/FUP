internal class Program
{
    private static void Main(string[] args)
    {
        Random random = new();
        List<int> numAleatorio = [];
        while (numAleatorio.Count < 6)
        {
            int num = random.Next(1, 61);
            if (!numAleatorio.Contains(num))
            {
                numAleatorio.Add(num);
            }
        }
        foreach (int num in numAleatorio)
        {
            Console.Write($"{num} ");
        }
        Console.ReadLine();
    }
}
