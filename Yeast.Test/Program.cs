using System;

namespace Yeast.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            long value = 0123456789;
            string encoded = String.Empty;
            long decoded = 0;
            
            Console.WriteLine($"Value: {value}");
            encoded = Yeast.Encode(value);
            Console.WriteLine($"Encode({value}) = {encoded}");
            decoded = Yeast.Decode(encoded);
            Console.WriteLine($"Decode({value}) = {decoded}");
            Console.WriteLine($"Decoded == Value ? {decoded == value}");

            Console.WriteLine("\nGenerating random keys within one call :");
            Console.WriteLine($"{Yeast.GenerateKey()} {Yeast.GenerateKey()} {Yeast.GenerateKey()}");

            Console.ReadLine();
        }
    }
}