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
            RemoveMoveButtons();
            foreach (Tuple<int,int> position in PossibleMoves())
            {
                Tuple<bool, bool> moveCheck = IsMove(position.Item1, position.Item2);
                if(moveCheck.Item1 && moveCheck.Item2)
                {
                    chessForm.GetPieceAt(position.Item1,position.Item2).pieceButton.BackColor = Color.Green;
                }
                else if(moveCheck.Item1 && !moveCheck.Item2)
                {
                    CreateMoveButton(position.Item1, position.Item2);
                }
            }
        }

        public void RemoveMoveButtons()
        {
            if (movesCount > 0)
            {
                for (int i = 0; i < movesCount; i++)
                {
                    chessForm.Controls.RemoveAt(0);
                }
                movesCount = 0;
            }

            foreach(Piece p in chessForm.allPieces)
            {
                if ((p.xPosition + p.yPosition) % 2 != 0)
                {
                    p.pieceButton.BackColor = Color.Peru;
                }
                else
                {
                    p.pieceButton.BackColor = Color.BurlyWood;
                }
            }
        }

        public Tuple<bool, bool> IsMove(int xPosition, int yPosition)
        {
            bool pieceFound = false;
            bool isMove = false;
            if(chessForm.IsPieceAt(xPosition, yPosition))
            {
                pieceFound = true;
                if (chessForm.GetPieceAt(xPosition,yPosition).white != this.white)
                {
                    isMove = true;
                }
            }
            if (!pieceFound)
            {
                isMove = true;
            }
            return new Tuple<bool, bool>(isMove, pieceFound);
        }

        public void CreateMoveButton(int xPosition, int yPosition)
        {
            Button moveButton = new Button();
            moveButton.Size = new Size(100, 100);
            moveButton.Location = new Point(xPosition * 100, yPosition * 100);
            moveButton.BackColor = Color.Green;
            moveButton.FlatStyle = FlatStyle.Flat;
            moveButton.FlatAppearance.BorderSize = 0;
            chessForm.Controls.Add(moveButton);
            moveButton.BringToFront();
            movesCount++;
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
