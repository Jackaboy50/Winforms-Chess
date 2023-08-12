using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal abstract class Piece
    {
        public static int movesCount = 0;
        public Form1 chessForm;
        public int xPosition;
        public int yPosition;
        public Button pieceButton;
        public Image image { get; protected set; }
        public bool white { get; private set; }

        public Piece(bool white, int xPosition, int yPosition, Form1 chessForm)
        {
            this.white = white;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.chessForm = chessForm;
        }

        public abstract void MoveDisplay();
        public abstract List<Tuple<int, int>> PossibleMoves();
        public void PieceClick(object sender, MouseEventArgs e)
        {
            if(movesCount > 0)
            {
                for(int i = 0; i < movesCount; i++)
                {
                    chessForm.Controls.RemoveAt(0);
                }
                movesCount = 0;
            }
            foreach (Tuple<int,int> position in PossibleMoves())
            {
                Console.WriteLine($"{position.Item1}, {position.Item2}");
                Button moveButton = new Button();
                moveButton.Size = new Size(100, 100);
                moveButton.Location = new Point(position.Item1 * 100, position.Item2 * 100);
                moveButton.BackColor = Color.Green;
                moveButton.FlatStyle = FlatStyle.Flat;
                moveButton.FlatAppearance.BorderSize = 0;
                chessForm.Controls.Add(moveButton);
                moveButton.BringToFront();
                movesCount++;
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
