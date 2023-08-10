using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal class Knight : Piece
    {
        public Knight(bool white) : base(white)
        {
            if (white)
            {
                image = new Bitmap("whitePieces\\whiteKnight.png");
            }
            else
            {
                image = new Bitmap("blackPieces\\blackKnight.png");
            }
        }

        public override void MoveDisplay()
        {

        }
    }
}
