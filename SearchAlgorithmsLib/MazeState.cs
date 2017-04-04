using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class MazeState<T>
    {
        private T state;    // the state represented by a string 
        private double cost;     // cost to reach this state (set by a setter)
        private MazeState<T> cameFrom;  // the state we came from to this state (setter)

        public MazeState(T state)    // CTOR 
        {
            this.state = state;
        }

        public bool Equals(MazeState<T> s) // we overload Object's Equals method 
        {
            return state.Equals(s.state);
        }

        public double GetCost()
        {
            return this.cost;
        }

        public MazeState<T> CameFrom()
        {
            return this.cameFrom;
        }
    }

}
