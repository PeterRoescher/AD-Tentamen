/*
 * Author: Peter Roescher
 * Studentnummer: s1020718
 */
using System;

namespace Opgave_3
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet012 set = new HashSet012(5, 3);
            set.Add("2");
            set.Add("101");
            set.Add("1");
            set.Add("02");
            set.Add("100");
            set.Add("12");
            set.Add("121");
            set.Add("122");
            set.Add("123");
            set.Add("124");
            set.Add("125");
            set.Add("126");
            set.Add("0123");
            set.Add("0124");
            set.Add("0125");
            Console.WriteLine(set.Add("0125"));
            Console.WriteLine(set.Add("0145"));
            Console.WriteLine(set);
        }
    }
}
