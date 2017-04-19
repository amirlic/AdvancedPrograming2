using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;

namespace SearchAlgorithmsLib
{
    class SearchableMaze<T> : ISearchable<T>
    {
        private Maze maze;
        public SearchableMaze(Maze m)
        {
            this.maze = m;
        }
        public MazeState<T> getInitialState()
        {
            return  new MazeState<T>(maze.InitialPos.ToString);
        }
        public MazeState<T> getGoalState()
        {
        }
        public List<MazeState<T>> getAllPossibleStates(MazeState<T> source)
        {
        }
    }
}
