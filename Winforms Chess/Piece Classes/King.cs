using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal class King : Piece
    {
        public King(bool white) : base(white)
        {
            if (white)
            {
                image = new Bitmap("whitePieces\\whiteKing.png");
            }
            else
            {
                image = new Bitmap("blackPieces\\blackKing.png");
            }
        }

        public override void MoveDisplay()
        {

        }
    }
}
