using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal class Queen : Piece
    {
        public Queen(bool white) : base(white)
        {
            if (white)
            {
                image = new Bitmap("whitePieces\\whiteQueen.png");
            }
            else
            {
                image = new Bitmap("blackPieces\\blackQueen.png");
            }
        }

        public override void MoveDisplay()
        {

        }
    }
}
