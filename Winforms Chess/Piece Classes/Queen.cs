using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal class Queen : Piece
    {
        public Queen(bool white,int xPosition, int yPosition) : base(white, xPosition, yPosition)
        {
            if (white)
            {
                image = new Bitmap("whitePieces\\whiteQueen.png");
            }
            else
            {
                image = new Bitmap("blackPieces\\blackQueen.png");
            }
            InitializeButton();
        }

        public override void MoveDisplay()
        {

        }
    }
}
