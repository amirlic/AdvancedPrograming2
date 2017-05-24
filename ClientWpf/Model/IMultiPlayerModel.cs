using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWpf.Model
{
    public interface IMultiPlayerModel : IGameModel
    {
        List<string> ListOfGames { get; set; }
    }
}
