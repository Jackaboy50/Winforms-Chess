﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal class Knight : Piece
    {
        public Knight(bool white, int xPosition, int yPosition) : base(white, xPosition, yPosition)
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

        public override void MoveDisplay()
        {

        }
    }
}