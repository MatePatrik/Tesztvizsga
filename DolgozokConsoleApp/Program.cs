using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozokConsoleApp
{
    internal class Program
    {
        static Adatbazis db = new Adatbazis();
        static List<Dolgozo> dolgozok;
        static void Main(string[] args)
        {
            dolgozok = db.getAllDolgozo();
            Feladat1();
            Feladat2();
            Feladat3();
            Feladat4();
            Console.WriteLine("Program vége!");
            Console.ReadLine();
        }

        private static void Feladat4()
        {
            Console.WriteLine("4.feladat:");
            foreach (var dolgozo in dolgozok.Where(x => x.reszleg == "asztalosműhely"))
            {
                Console.WriteLine($"\t{dolgozo.nev}.");
            }
        }

        private static void Feladat3()
        {
            Console.WriteLine("3.feladat:");
            foreach (var dolgozo in dolgozok.GroupBy(x => x.reszleg).Select(y => new {reszleg = y.Key, letszam = y.Count()}))
            {
                Console.WriteLine($"\t{dolgozo.reszleg} {dolgozo.letszam}.");
            }
        }

        private static void Feladat2()
        {
            Console.WriteLine("2.feladat:");
            int MaxBer = dolgozok.Max(x => x.ber);
            Console.WriteLine($"\tA legnagyobb bérel rendelkező: {dolgozok.First(x => x.ber == MaxBer).nev}.");
        }

        private static void Feladat1()
        {
            Console.WriteLine("1.feladat:");
            Console.WriteLine($"\tA dolgozók száma: {dolgozok.Count} fő.");
        }
    }
}
