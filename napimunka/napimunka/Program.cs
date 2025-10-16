using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace napimunka
{
    internal class Program
    {
       List<NapiMunka> napiMunkak = new List<NapiMunka>();
        static void Main(string[] args)
        {
            // 3. feladat
               StreamReader sr = new StreamReader("diszek.txt");
               while(!sr.EndOfStream)
                {
                    napiMunkak.Add(new NapiMunka(sr.ReadLine()));
                }
               sr.Close();

            // 4. feladat: Összesen elkészített díszek
            Console.WriteLine($"4. feladat: Összesen {NapiMunka.KeszultDb} darab dísz készült.");

            // 5. feladat: Volt-e nap, amikor nem készült dísz
            bool voltNullaKeszitesuNap = false;
            foreach (var munka in napiMunkak)
            {
                if (munka.HarangKesz + munka.AngyalkaKesz + munka.FenyofaKesz == 0)
                {
                    voltNullaKeszitesuNap = true;
                    break;
                }
            }
            Console.WriteLine($"5. feladat: {(voltNullaKeszitesuNap ? "Volt" : "Nem volt")} olyan nap, amikor egyetlen dísz sem készült.");

            // 6. feladat: Napi készlet
            Console.WriteLine("6. feladat:");
            int nap;
            do
            {
                Console.Write("Adja meg a keresett napot [1-40]: ");
            } while (!int.TryParse(Console.ReadLine(), out nap) || nap < 1 || nap > 40);

            int keszletHarang = 0;
            int keszletAngyalka = 0;
            int keszletFenyofa = 0;

            for (int i = 0; i < nap; i++)
            {
                keszletHarang += napiMunkak[i].HarangKesz + napiMunkak[i].HarangEladott;
                keszletAngyalka += napiMunkak[i].AngyalkaKesz + napiMunkak[i].AngyalkaEladott;
                keszletFenyofa += napiMunkak[i].FenyofaKesz + napiMunkak[i].FenyofaEladott;
            }
            Console.WriteLine($"A(z) {nap}. nap végén {keszletHarang} harang, {keszletAngyalka} angyalka és {keszletFenyofa} fenyőfa maradt készleten.");

            // 7. feladat: Legtöbbet eladott dísz
            Console.WriteLine("7. feladat:");
            var eladottDiszek = new Dictionary<string, int>
            {
                { "Harang", 0 },
                { "Angyalka", 0 },
                { "Fenyőfa", 0 }
            };

            foreach (var munka in napiMunkak)
            {
                eladottDiszek["Harang"] -= munka.HarangEladott;
                eladottDiszek["Angyalka"] -= munka.AngyalkaEladott;
                eladottDiszek["Fenyőfa"] -= munka.FenyofaEladott;
            }

            int maxEladott = eladottDiszek.Values.Max();
            Console.WriteLine($"Legtöbbet eladott dísz: {maxEladott} darab");
            foreach (var item in eladottDiszek)
            {
                if (item.Value == maxEladott)
                {
                    Console.WriteLine(item.Key);
                }
            }

            // 8. feladat: Napi bevételek kiírása fájlba
            try
            {
                using (var writer = new StreamWriter("bevetel.txt"))
                {
                    int legalabb10000 = 0;
                    foreach (var munka in napiMunkak)
                    {
                        int bevetel = munka.NapiBevetel();
                        if (bevetel >= 10000)
                        {
                            writer.WriteLine($"{munka.Nap}:{bevetel}");
                            legalabb10000++;
                        }
                    }
                    writer.WriteLine($"{legalabb10000} napon volt legalább 10000 Ft a bevétel.");
                }
                Console.WriteLine("8. feladat: A bevetel.txt állomány kiírása sikeres volt.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hiba a bevetel.txt fájl írása közben: {e.Message}");
            }
        }
    }
}
