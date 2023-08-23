using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal class Queen : Piece
    {
        public Queen(bool white, int xPosition, int yPosition, Form1 chessForm) : base(white, xPosition, yPosition, chessForm)
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

        public override List<Tuple<int, int>> PossibleMoves()
        {
            List<Tuple<int, int>> possibleMoves = new List<Tuple<int, int>>();
            for(int i = 1; i < 8; i++)
            {
                possibleMoves.Add(new Tuple<int, int>(xPosition + i, yPosition));
                possibleMoves.Add(new Tuple<int,int>(xPosition - i, yPosition));
                possibleMoves.Add(new Tuple<int, int>(xPosition, yPosition + i));
                possibleMoves.Add(new Tuple<int, int>(xPosition, yPosition - i));

                possibleMoves.Add(new Tuple<int, int>(xPosition + i, yPosition + i));
                possibleMoves.Add(new Tuple<int, int>(xPosition + i, yPosition - i));
                possibleMoves.Add(new Tuple<int, int>(xPosition - i, yPosition + i));
                possibleMoves.Add(new Tuple<int, int>(xPosition - i, yPosition - i));
            }
            return possibleMoves;
        }
    }
}
