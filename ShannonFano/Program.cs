using System;
using System.Collections.Generic;

namespace ShannonFano
{
    class Program
    {
        static void Main(string[] args)
        {
            var shannonFanoCoding = new ShannonFanoCoding();

            Console.Write("Enter text: ");

            var text = Console.ReadLine();

            var (symbols, code) = shannonFanoCoding.Code(text);

            var memorySize = CalculateMemorySize(symbols);

            var sourceMemorySize = text.Length * 8;

            var compressionRatio = memorySize / (float)sourceMemorySize * 100;

            Console.WriteLine($"Memory size source text: {sourceMemorySize}bit");

            Console.WriteLine($"Memory size encoded text: {memorySize}bit");
            
            Console.WriteLine($"Compression ratio: {compressionRatio}%");

            Console.WriteLine("Symbol\tCode\tFrequency");

            foreach (var symbol in symbols)
            {
                Console.WriteLine($"{symbol.Value}\t{symbol.Code}\t{symbol.Count}");
            }

            Console.WriteLine($"Encoded text: {code}");

            var encodedText = Console.ReadLine();

            var decoding = shannonFanoCoding.Decode(encodedText);

            Console.WriteLine($"Source text: {decoding}");
        }

        static int CalculateMemorySize(List<Symbol> symbols)
        {
            var memorySize = 0;

            foreach (var symbol in symbols)
            {
                memorySize += symbol.Count * symbol.Code.Length;
            }

            return memorySize;
        }
    }
}