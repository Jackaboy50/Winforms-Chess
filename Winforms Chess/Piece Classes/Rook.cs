using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal class Rook : Piece
    {
        public Rook(bool white) : base(white)
        {
            if (white)
            {
                image = new Bitmap("whitePieces\\whiteRook.png");
            }
            else
            {
                image = new Bitmap("blackPieces\\blackRook.png");
            }
        }

        public override void MoveDisplay()
        {

        }
    }
}
