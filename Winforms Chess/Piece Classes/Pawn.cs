﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal class Pawn : Piece
    {
        public Pawn(bool white, int xPosition, int yPosition, Form1 chessForm) : base(white, xPosition, yPosition, chessForm)
        {
            if (white)
            {
                image = new Bitmap("whitePieces\\whitePawn.png");
            }
            else
            {
                image = new Bitmap("blackPieces\\blackPawn.png");
            }
            InitializeButton();
        }

        public override List<Tuple<int,int>> PossibleMoves()
        {
            List<Tuple<int,int>> possibleMoves = new List<Tuple<int,int>>();
            if (white)
            {
                possibleMoves.Add(new Tuple<int, int>(xPosition, yPosition - 1));
                possibleMoves.Add(new Tuple<int, int>(xPosition - 1, yPosition - 1));
                possibleMoves.Add(new Tuple<int, int>(xPosition + 1, yPosition - 1));
                possibleMoves.Add(new Tuple<int, int>(xPosition, yPosition - 2));
            }
            else
            {
                possibleMoves.Add(new Tuple<int, int>(xPosition, yPosition + 1));
                possibleMoves.Add(new Tuple<int, int>(xPosition - 1, yPosition + 1));
                possibleMoves.Add(new Tuple<int, int>(xPosition + 1, yPosition + 1));
                possibleMoves.Add(new Tuple<int, int>(xPosition, yPosition + 2));
            }
            
            return possibleMoves;
        }
    }
}
