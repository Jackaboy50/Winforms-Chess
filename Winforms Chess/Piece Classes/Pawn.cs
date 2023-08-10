using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal class Pawn : Piece
    {
        public Pawn(bool white) : base(white)
        {
            if(white)
            {
                image = new Bitmap("whitePieces\\whitePawn.png");
            }
            else
            {
                image = new Bitmap("blackPieces\\blackPawn.png");
            }
        }

        public override void MoveDisplay()
        {

        }
    }
}
