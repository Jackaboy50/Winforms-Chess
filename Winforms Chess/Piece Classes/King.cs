using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal class King : Piece
    {
        public King(bool white, int xPosition, int yPosition, Form1 chessForm) : base(white, xPosition, yPosition, chessForm)
        {
            if (white)
            {
                image = new Bitmap("whitePieces\\whiteKing.png");
            }
            else
            {
                image = new Bitmap("blackPieces\\blackKing.png");
            }
            InitializeButton();
        }
        public override List<Tuple<int, int>> PossibleMoves()
        {
            List<Tuple<int, int>> possibleMoves = new List<Tuple<int, int>>();
            for(int i = -1; i < 2; i++)
            {
                possibleMoves.Add(new Tuple<int, int>(xPosition - 1, yPosition + i ));
                possibleMoves.Add(new Tuple<int, int>(xPosition + 1, yPosition + i));
            }
            possibleMoves.Add(new Tuple<int, int>(xPosition, yPosition - 1));
            possibleMoves.Add(new Tuple<int, int>(xPosition, yPosition + 1));
            return possibleMoves;
        }
    }
}
