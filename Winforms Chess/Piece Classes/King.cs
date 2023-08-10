﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal class King : Piece
    {
        public King(bool white, int xPosition, int yPosition) : base(white, xPosition, yPosition)
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

        public override void MoveDisplay()
        {

        }
    }
}