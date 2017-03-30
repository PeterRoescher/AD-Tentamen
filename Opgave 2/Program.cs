/*
 * Author: Peter Roescher
 * Studentnummer: s1020718
 */
using System;

namespace Opgave_2
{
    class Program
    {
        static void Main(string[] args)
        {
            MySortedLinkedList list = new MySortedLinkedList();
            list.AddFirst(2);
            list.AddFirst(4);
            list.AddFirst(1);
            list.AddFirst(3);

            Console.WriteLine(list.Contains(1));
            Console.WriteLine(list);
            Console.WriteLine(list.ToStringSorted());
        }
    }
}
