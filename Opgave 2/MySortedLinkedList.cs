using System.Text;
/*
 * Author: Peter Roescher
 * Studentnummer: s1020718
 */
namespace Opgave_2
{
    public class MySortedLinkedList
    {
        private Node First { get; set; }
        private Node FirstSorted { get; set; }

        public int Size { get; private set; }

        public MySortedLinkedList()
        {
            Size = 0;
            First = null;
            FirstSorted = null;
            //_hashArray = new int[7];
        }

        public void AddFirst(int data)
        {
            Node newNode = new Node(data);
            newNode.Next = First;
            First = newNode;

            if (FirstSorted == null)
            {
                FirstSorted = newNode;
            }
            else if (FirstSorted.Data > data)
            {
                newNode.NextSorted = FirstSorted;
                FirstSorted = newNode;
            }
            else
            {
                Node sortedNode = FirstSorted;
                while (sortedNode?.NextSorted != null && sortedNode.NextSorted.Data < data)
                {
                    sortedNode = sortedNode.NextSorted;
                }
                newNode.NextSorted = sortedNode.NextSorted;
                sortedNode.NextSorted = newNode;
            }

            Size++;
            //HashImplementation(data);
        }


        public bool Contains(int data)
        {
            //Ik vermoed dat dit wordt bedoeld door de opdracht en niet een bijgehouden schaduw 
            //oplossing die ik ondertussen heb uitgecomment :)
            Node d = FirstSorted;
            while (d.Data != data && data < d.Data)
            {
                d = d.NextSorted;
            }
            return d.Data == data;

            //int initialHashValue = HashValue(data, _hashArray.Length);
            //int hashValue = initialHashValue;

            ////linair probing
            //while (_hashArray[hashValue] != data && _hashArray[(hashValue + 1) % _hashArray.Length] != 0)
            //{
            //    hashValue += 1;
            //}
            //return _hashArray[hashValue] == data;
        }

        #region HashImplementation for efficient contains
        //private int[] _hashArray; //schaduw array voor een zo effiecient mogelijke 

        //private void HashImplementation(int data)
        //{
        //    int hashValue = HashValue(data, _hashArray.Length);
        //    while (_hashArray[hashValue] != 0) //linair probing
        //    {
        //        hashValue = HashValue(hashValue + 1, _hashArray.Length);
        //    }
        //    _hashArray[hashValue] = data;
        //    if ((double)Size / _hashArray.Length >= 0.5) Rehash();
        //}

        //private void Rehash()
        //{
        //    int[] newArray = new int[GetNextPrime(_hashArray.Length * 2)];
        //    for (int i = 0; i < Size; i++)
        //    {
        //        if (_hashArray[i] == 0) continue;
        //        int newHash = HashValue(_hashArray[i], newArray.Length);
        //        int iHash = 1;
        //        while (!newArray[newHash].Equals(0))
        //        {
        //            newHash += 1;
        //            newHash = newHash % newArray.Length;
        //            iHash++;
        //        }
        //        newArray[newHash] = _hashArray[i];
        //    }
        //    _hashArray = newArray;

        //}

        //public int HashValue(int data, int tableSize)
        //{
        //    return data % tableSize;
        //}

        //public static uint GetNextPrime(int number)
        //{
        //    if (number % 2 == 0) number++;
        //    uint max = (uint)Math.Ceiling(Math.Sqrt(number));

        //    for (uint possiblePrime = (uint)number + 2; possiblePrime < UInt32.MaxValue; possiblePrime += 2)
        //    {
        //        if (IsPrime(possiblePrime)) return possiblePrime;
        //    }
        //    throw new Exception("No prime found");
        //}

        //private static bool IsPrime(uint possiblePrime)
        //{
        //    if (possiblePrime < 2) return false;
        //    if (possiblePrime == 2 || possiblePrime == 3) return true;
        //    if (possiblePrime % 2 == 0) return false;

        //    for (int iL = 3; iL * iL < possiblePrime; iL += 2)
        //    {
        //        if (possiblePrime % iL == 0)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        #endregion


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node node = First;
            while (node != null)
            {
                sb.Append(node.Data);
                if (node.Next != null)
                {
                    sb.Append(" -> ");
                }
                node = node.Next;
            }
            return sb.ToString();
        }

        public string ToStringSorted()
        {
            StringBuilder sb = new StringBuilder();
            Node node = FirstSorted;
            sb.Append("[");
            while (node != null)
            {
                sb.Append(node.Data);
                if (node.NextSorted != null)
                {
                    sb.Append(", ");
                }
                node = node.NextSorted;
            }
            sb.Append("]");
            return sb.ToString();
        }

        private class Node
        {
            public Node Next { get; set; }
            public Node NextSorted { get; set; }

            public int Data { get; private set; }

            public Node(int data)
            {
                Data = data;
            }
        }
    }
}
