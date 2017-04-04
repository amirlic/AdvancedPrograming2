using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class Solution<T>
    {
        private List<T> sol;
        public Solution(List<T> sol)
        {
            this.sol = sol;
        }
        public List<T> GetSol()
        {
            return this.sol;
        }
    }
}
