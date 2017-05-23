using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWpf.Model
{
    public class SinglePlayerMazeModel
    {
        private Client tcp;
        public SinglePlayerMazeModel()
        {
            int cols = 2, rows = 2;
            string name = "name";
            tcp = new Client(name,rows,cols,1);
            tcp.Start();
        }

    }
}
