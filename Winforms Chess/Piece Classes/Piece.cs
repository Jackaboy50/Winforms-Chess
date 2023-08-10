using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal abstract class Piece
    {
        public int xPosition;
        public int yPosition;
        public Button pieceButton;
        public Image image { get; protected set; }
        public bool white { get; private set; }

        public Piece(bool white, int xPosition, int yPosition)
        {
            this.white = white;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public abstract void MoveDisplay();
        public void InitializeButton()
        {
            pieceButton = new Button();
            pieceButton.Size = new Size(100, 100);
            pieceButton.Location = new Point(xPosition * 100, yPosition * 100);
            pieceButton.Image = image;

            if((xPosition + yPosition) % 2 != 0)
            {
                pieceButton.BackColor = Color.Peru;
            }
            else
            {
                pieceButton.BackColor = Color.BurlyWood;
            }

            pieceButton.FlatStyle = FlatStyle.Flat;
            pieceButton.FlatAppearance.BorderSize = 0;
            pieceButton.BringToFront();
        }
    }
}
