using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SearchAlgorithmsLib
{
    /// <summary>
    /// BFS class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="SearchAlgorithmsLib.Searcher{T}" />
    public class BFS<T> : Searcher<T>
    {
        private Solution<T> sol = new Solution<T>();

        /// <summary>
        /// Searches the specified searchable.
        /// </summary>
        /// <param name="searchable">The searchable.</param>
        /// <returns></returns>
        public override Solution<T> Search(ISearchable<T> searchable)
        { // Searcher's abstract method overriding
            AddToOpenList(searchable.getInitialState(), 0); // inherited from Searcher
            HashSet<MazeState<T>> closed = new HashSet<MazeState<T>>();

            while (OpenListSize > 0)
            {
                MazeState<T> curr = PopOpenList(); // inherited from Searcher, removes the best state
                closed.Add(curr);
                if (curr.Equals(searchable.getGoalState()))
                {
                    sol = BackTrace(curr); // private method, back traces through the parents calling the delegated method, returns a list of states with n as a parent
                    return sol;

                }



                List<MazeState<T>> succerssors = searchable.getAllPossibleStates(curr);

                foreach (MazeState<T> suc in succerssors)
                {
                    if (!closed.Contains(suc) && !IsContaining(suc))
                    {
                        suc.setCameFrom(curr); // already done by getSuccessors
                        AddToOpenList(suc, curr.GetCost() + 1);
                    }
                    else
                    {
                        //I check thet the successor's is not 0 first because it is more efficient
                        //because if the successor's cost is 0 than we will not check the second rule which depends on
                        //the first rule
                        if ((suc.GetCost() != 0) && (curr.GetCost() + 1 > suc.GetCost()))
                        {
                            if (!IsContaining(suc))
                            {
                                AddToOpenList(suc, curr.GetCost() + 1);
                                IncNumberOfNodesEvaluated();
                            }
                            else
                            {
                                ChangeMemberPriority(suc, curr.GetCost() + 1);
                                IncNumberOfNodesEvaluated();
                            }
                        }
                    }

                }

            }
            return sol;
        }
    }
}