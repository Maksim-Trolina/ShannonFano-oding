using System;
using System.Collections;

namespace ShannonFano
{
    class Program
    {
        static void Main(string[] args)
        {
            /*try
            {
                IComparer comparer = new IntComparer();

                var tree = new AVLTree<int, string>(comparer);

                tree.Insert(1, "ffd");

                tree.Insert(5, "ggav");

                tree.Insert(7, "bnb");

                tree.Insert(0, "tgg");

                tree.Insert(3, "ll");

                tree.Insert(11, "65hff");
                

                tree.Remove(0);

                tree.Remove(1);

                var val = tree.Find(5);
                
                Console.WriteLine(val);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }*/
            
            ShannonFanoCoding shannonFanoCoding = new ShannonFanoCoding();

            var text = Console.ReadLine();

            var data = shannonFanoCoding.Coding(text);

            foreach (var s in data)
            {
                Console.WriteLine($"{s.Value}: {s.Code}");
            }

            var code = Console.ReadLine();

            var res = shannonFanoCoding.Decoding(code);
            
            Console.WriteLine(res);
        }
    }
}