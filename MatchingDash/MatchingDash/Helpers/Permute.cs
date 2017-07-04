using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingDash.Helpers
{
    public class Permute
    {
        public List<int> results=new List<int>();
        public  void permuter(string s) { permuter("", s); }
        public  void permuter(string prefix, string s)
        {
            
            int N = s.Length;
            if (N == 0)
                results.Add(int.Parse(prefix));
            else
            {
                for (int i = 0; i < N; i++)
                    permuter(prefix + s.ElementAt<char>(i), s.Substring(0, i) + s.Substring(i + 1, N));
            }
        }
    }
}
