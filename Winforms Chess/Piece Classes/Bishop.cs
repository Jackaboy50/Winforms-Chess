using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal class Bishop : Piece
    {
        public Bishop(bool white, int xPosition, int yPosition, Form1 chessForm) : base(white, xPosition, yPosition, chessForm)
        {
            if (white)
            {
                image = new Bitmap("whitePieces\\whiteBishop.png");
            }
            else
            {
                image = new Bitmap("blackPieces\\blackBishop.png");
            }
            InitializeButton();
        }

        public override void MoveDisplay()
        {

        }
        public override List<Tuple<int, int>> PossibleMoves()
        {
            List<Tuple<int, int>> possibleMoves = new List<Tuple<int, int>>();

            return possibleMoves;
        }
    }
}
