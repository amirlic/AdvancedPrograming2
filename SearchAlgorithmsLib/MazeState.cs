﻿using System;
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
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public MazeState(T state)    // CTOR 
        {
            this.state = state;
            this.cameFrom = null;
        }

        /// <summary>
        /// Equalses the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public bool Equals(MazeState<T> s) // we overload Object's Equals method 
        {
            return state.Equals(s.state);
        }
        public T getState()
        {
            return this.state;
        }

        /// <summary>
        /// Gets the cost.
        /// </summary>
        /// <returns>the costof the current state </returns>
        public double GetCost()
        {
            return this.cost;
        }

        /// <summary>
        /// Sets the cost.
        /// </summary>
        /// <param name="cost">The cost.</param>
        public void SetCost(double cost)
        {
            this.cost = cost;
        }


        public MazeState<T> CameFrom()
        {
            return this.cameFrom;
        }

        public void setCameFrom(MazeState<T> from)
        {
            this.cameFrom = from;
        }

        public override string ToString()
        {
            return this.state.ToString();
        }

        public override int GetHashCode()
        {
            return base.ToString().GetHashCode();
        }
    }

}
