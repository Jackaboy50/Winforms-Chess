using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal class Knight : Piece
    {
        public Knight(bool white, int xPosition, int yPosition, Form1 chessForm) : base(white, xPosition, yPosition, chessForm)
        {
            if (white)
            {
                image = new Bitmap("whitePieces\\whiteKnight.png");
            }
            else
            {
                image = new Bitmap("blackPieces\\blackKnight.png");
            }
            InitializeButton();
        }
        protected override List<Tuple<int, int>> PossibleMoves()
        {
            List<Tuple<int, int>> possibleMoves = new List<Tuple<int, int>>();
            for(int i = -1; i < 2; i += 2)
            {
                AddMove(possibleMoves, xPosition + i, yPosition - 2);
                AddMove(possibleMoves, xPosition + i, yPosition + 2);
                AddMove(possibleMoves, xPosition - 2, yPosition + i);
                AddMove(possibleMoves, xPosition + 2, yPosition + i);
            }
            return possibleMoves;
        }

        protected override bool LineOfSight(int xPosition, int yPosition)
        {
            return true;
        }
    }
}
