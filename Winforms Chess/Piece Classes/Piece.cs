using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal abstract class Piece
    {
        public Image image { get; protected set; }
        public bool white { get; private set; }

        public Piece(bool white)
        {
            this.white = white;
        }

        public abstract void MoveDisplay();
    }
}
