using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal class GameController
    {
        BoardController boardController;
        public GameController(BoardController boardController)
        {
            this.boardController = boardController;
        }
    }
}
