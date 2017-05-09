using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    static class Wins
    {
        public static IList<byte[]> Combos { get; }
        static Wins()
        {
            Combos = new List<byte[]>()
            {
                new byte[] { 1, 2, 3 },
                new byte[] { 4, 5, 6 },
                new byte[] { 7, 8, 9 },
                new byte[] { 1, 4, 7 },
                new byte[] { 2, 5, 8 },
                new byte[] { 3, 6, 9 },
                new byte[] { 1, 5, 9 },
                new byte[] { 3, 5, 7 }
            };
        }
    }
}
