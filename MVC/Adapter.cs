using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;
using MazeLib;
using Newtonsoft.Json.Linq;

namespace MVC
{
    public class Adapter : ISearchable<Position>
    {
        private Maze maze;


        public Adapter(Maze maze)
        {
            this.maze = maze;
        }
        /// <summary>
        /// Gets all possible states.
        /// </summary>
        /// <param name="s">The state to get all of the neighbours of.</param>
        /// <returns>A list of all of s's free neighbours</returns>
        public List<MazeState<Position>> getAllPossibleStates(MazeState<Position> s)
        {
            List<MazeState<Position>> allPossible = new List<MazeState<Position>>();
            Position curr = s.getState();
            //In all of these I first check if the neighbour is within the limits of the maze
            //because it is just more efficient

            //In addition we check the neighbours in the next order:
            //up
            //right
            //down
            //left

            //up
            if (curr.Row - 1 >= 0 && this.maze[curr.Row - 1, curr.Col] == CellType.Free)
            {
                allPossible.Add(new MazeState<Position>(new Position(curr.Row - 1, curr.Col)));
            }

            //right
            if (curr.Col + 1 <= this.maze.Cols - 1 && this.maze[curr.Row, curr.Col + 1] == CellType.Free)
            {
                allPossible.Add(new MazeState<Position>(new Position(curr.Row, curr.Col + 1)));
            }

            //left
            if (curr.Col - 1 <= this.maze.Cols - 1 && this.maze[curr.Row, curr.Col - 1] == CellType.Free)
            {
                allPossible.Add(new MazeState<Position>(new Position(curr.Row, curr.Col - 1)));
            }

            //below
            if (curr.Row + 1 <= this.maze.Rows - 1 && this.maze[curr.Row + 1, curr.Col] == CellType.Free)
            {
                allPossible.Add(new MazeState<Position>(new Position(curr.Row + 1, curr.Col)));
            }
            return allPossible;
        }

        public MazeState<Position> getGoalState()
        {
            MazeState<Position> goal = new MazeState<Position>(maze.GoalPos);
            return goal;
        }

        public MazeState<Position> getInitialState()
        {
            MazeState<Position> entrance = new MazeState<Position>(maze.InitialPos);
            return entrance;
        }
    }
}

