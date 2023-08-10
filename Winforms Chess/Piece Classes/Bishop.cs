using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal class Bishop : Piece
    {
        public Bishop(bool white) : base(white)
        {
            if (white)
            {
                image = new Bitmap("whitePieces\\whiteBishop.png");
            }
            else
            {
                image = new Bitmap("blackPieces\\blackBishop.png");
            }
        }

        public override void MoveDisplay()
        {

        }
    }
}
