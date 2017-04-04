using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace SearchAlgorithmsLib
{
    public abstract class Searcher<T> : ISearcher<T>
    {
        private SimplePriorityQueue<MazeState<T>> openList;
        private int evaluatedNodes;
        public Searcher() {
            openList = new SimplePriorityQueue<MazeState<T>>();
            evaluatedNodes = 0;
        }
        protected MazeState<T> popOpenList() {
            evaluatedNodes++;
            return openList.poll;
        }
        // a property of openList 
        public int OpenListSize {
            // it is a read-only property :) 
            get
            {
                return openList.Count;
            }
        }
        // ISearcher’s methods:
        public int getNumberOfNodesEvaluated() {
            return evaluatedNodes;
        }
        public abstract Solution<T> search(ISearchable<T> searchable);
    }
}
