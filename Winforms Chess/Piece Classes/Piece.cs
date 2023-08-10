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
        public abstract List<Tuple<int, int>> PossibleMoves();
        public void PieceClick(object sender, MouseEventArgs e)
        {
            foreach (Tuple<int,int> position in PossibleMoves())
            {
                Button moveButton = new Button();
                moveButton.Size = new Size(100, 100);
                moveButton.Location = new Point(position.Item1 * 100, position.Item2 * 100);
                moveButton.BackColor = Color.Green;
            }
        }
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
            pieceButton.MouseDown += new MouseEventHandler(PieceClick);
            pieceButton.BringToFront();
        }
    }
}
