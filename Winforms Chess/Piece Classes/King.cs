﻿using System;
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
        protected override List<Tuple<int, int>> PossibleMoves()
        {
            List<Tuple<int, int>> possibleMoves = new List<Tuple<int, int>>();
            for(int i = -1; i < 2; i++)
            {
                AddMove(possibleMoves, xPosition - 1, yPosition + i);
                AddMove(possibleMoves, xPosition + 1, yPosition + 1);
            }
            AddMove(possibleMoves, xPosition, yPosition - 1);
            AddMove(possibleMoves, xPosition, yPosition + 1);
            return possibleMoves;
        }

        protected override bool LineOfSight(int xPosition, int yPosition)
        {
            return CardinalLineOfSight(xPosition, yPosition) && DiagonalLineOfSight(xPosition, yPosition);
        }
    }
}
