/*
 * Author: Peter Roescher
 * Studentnummer: s1020718
 */
using System.Text;

namespace Opgave_3
{
    public class HashSet012
    {
        private int _initCapacity;
        private string[][] _tabel;
        public HashSet012(int tabelGrootte, int initCapacity)
        {
            _tabel = new string[tabelGrootte][];
            _initCapacity = initCapacity;
        }

        public bool Add(string s)
        {
            int hashValue = HashValue(s, _tabel.Length);
            
            if (_tabel[hashValue] == null)
            {
                _tabel[hashValue] = new string[_initCapacity];
                _tabel[hashValue][0] = s;
            }
            else
            {
                int i = 0;
                while (i < _tabel[hashValue].Length && _tabel[hashValue][i] != null)
                {
                    if (_tabel[hashValue][i].Equals(s)) return false;
                    i++;
                }
                if (i >= _tabel[hashValue].Length)
                {
                    Doubling(hashValue);
                }
                _tabel[hashValue][i] = s;
            }
            return true;
        }

        private void Doubling(int hashValue)
        {
            string[] newArray = new string[_tabel[hashValue].Length * 2];
            for (int i = 0; i < _tabel[hashValue].Length; i++)
            {
                newArray[i] = _tabel[hashValue][i];
            }
            _tabel[hashValue] = newArray;
        }

        private static int HashValue(string str, int tabelsize)
        {
            uint hashValue = 0;
            for (int i = 0; i < str.Length; i++)
            {
                hashValue = hashValue * 31 + (uint)str[i];
            }
            return (int)(hashValue % tabelsize);
        }
        


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _tabel.Length; i++)
            {
                sb.Append($"[{i}]: ");
                if (_tabel[i] == null)
                {
                    sb.AppendLine("null");
                }
                else
                {
                    sb.Append("[");
                    for (int iCell = 0; iCell < _tabel[i].Length; iCell++)
                    {
                        sb.Append(_tabel[i][iCell] ?? "#");
                        if (iCell + 1 < _tabel[i].Length) sb.Append(", ");
                    }
                    sb.AppendLine("]");
                }
            }
            return sb.ToString();
        }

    }
}
