using System;

class VeryHeavyObject
{
    private byte[] data = new byte[100 * 1024];
}
class HeavyObject
{
    private byte[] data = new byte[75 * 1024];
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1) 100кб");
        VeryHeavyObject heavy = new VeryHeavyObject();
        Console.WriteLine($"Поколение в начале: {GC.GetGeneration(heavy)}");
        Console.WriteLine($"Памяти занято: {GC.GetTotalMemory(false)}");
        GC.Collect();
        Console.WriteLine($"Поколение объекта после GC.Collect(): {GC.GetGeneration(heavy)}");
        for (int i = 0; i < 1000000; i++) { object obj = new object(); }
        Console.WriteLine($"Поколение HeavyObject после цикла: {GC.GetGeneration(heavy)}");

        Console.WriteLine("1) 75кб");
        HeavyObject normal = new HeavyObject();
        Console.WriteLine($"Поколение в начале: {GC.GetGeneration(normal)}");
        Console.WriteLine($"Памяти занято: {GC.GetTotalMemory(false)}");
        GC.Collect();
        Console.WriteLine($"Поколение объекта после GC.Collect(): {GC.GetGeneration(normal)}");
        for (int i = 0; i < 10000000; i++) { object obj = new object(); }
        Console.WriteLine($"Поколение HeavyObject после цикла: {GC.GetGeneration(normal)}");
    }
}