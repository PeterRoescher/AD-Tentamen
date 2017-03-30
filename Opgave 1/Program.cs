/*
 * Author: Peter Roescher
 * Studentnummer: s1020718
 */
using System;

namespace Opgave_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(kwadratenLijst(-1));
            Console.WriteLine(kwadratenLijst(0));
            Console.WriteLine(kwadratenLijst(1));
            Console.WriteLine(kwadratenLijst(2));
            Console.WriteLine(kwadratenLijst(5));
        }

        static string kwadratenLijst(int n)
        {
            if (n < 0) return "_";

            return kwadratenLijst(n - 1) + $"/{(n * n)}\\_";
        }
    }
}
