using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominoconsole
{
    class Program
    {
        static List<domino> list = new List<domino>();
        static void Main(string[] args)
        {
            Console.WriteLine("\n2.feladat");
            StreamReader reader = new StreamReader("domino.txt");
            while (!reader.EndOfStream)
            {
                list.Add(new domino(reader.ReadLine()));
            }
            reader.Close();
            Console.WriteLine("\n3.feladat");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine($"Dominók száma: {list.Count}");

            Console.WriteLine("\n4.feladat");
            Console.Write("Sorszám:"); int sorszam = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"A(z) {sorszam}-nak megfelelő dominó: {list[sorszam - 1]}");

            Console.WriteLine("\n5.feladat");
            int db = 0;
            foreach (var item in list)
            {
                if (item.left == item.right)
                {
                    db++;
                }
            }
            Console.WriteLine($"Dupla dominók száma: {db}db");

            Console.WriteLine("\n6.feladat");
            bool szabalyos = true;
            for (int i = 0; i < list.Count-1; i++)
            {
                if (list[i].right != list[i+1].left)
                {
                    szabalyos = false;
                    
                }
            }
            Console.WriteLine(szabalyos?"Szabályosak az illesztések":"Nem szabályosak az illesztések");
        }
    }    
}
