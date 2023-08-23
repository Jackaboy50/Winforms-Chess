using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

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
                AddMove(possibleMoves, xPosition + i, yPosition);
                AddMove(possibleMoves, xPosition - i, yPosition);
                AddMove(possibleMoves, xPosition, yPosition + i);
                AddMove(possibleMoves, xPosition, yPosition - i);


                AddMove(possibleMoves, xPosition + i, yPosition + i);
                AddMove(possibleMoves, xPosition + i, yPosition - i);
                AddMove(possibleMoves, xPosition - i, yPosition + i);
                AddMove(possibleMoves, xPosition - i, yPosition - i);
            }
            return possibleMoves;
        }

        protected override bool LineOfSight(int xPosition, int yPosition)
        {
            return CardinalLineOfSight(xPosition, yPosition) && DiagonalLineOfSight(xPosition, yPosition);
        }
    }
}
