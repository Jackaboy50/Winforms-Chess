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
        public abstract List<Tuple<int, int>> PossibleMoves();
        protected void PieceClick(object sender, MouseEventArgs e)
        {
            RemoveMoveButtons();
            foreach (Tuple<int,int> position in PossibleMoves())
            {
                Tuple<bool, bool> moveCheck = IsMove(position.Item1, position.Item2);
                if(moveCheck.Item1 && moveCheck.Item2 && LineOfSight(position.Item1, position.Item2))
                {
                    chessForm.GetPieceAt(position.Item1,position.Item2).pieceButton.BackColor = Color.Green;
                }
                else if(moveCheck.Item1 && !moveCheck.Item2 && LineOfSight(position.Item1, position.Item2))
                {
                    CreateMoveButton(position.Item1, position.Item2);
                }
            }
        }

        protected virtual bool LineOfSight(int xPosition, int yPosition)
        {
            if(this.yPosition > yPosition)
            {
                //Check Up
                for (int i = this.yPosition; i > yPosition; i--)
                {
                    if (chessForm.IsPieceAt(xPosition, i) && chessForm.GetPieceAt(xPosition, i) != this)
                    {
                        return false;
                    }
                }
            }
            else
            {
                //Check down
                for (int i = this.yPosition; i < yPosition; i++)
                {
                    if (chessForm.IsPieceAt(xPosition, i) && chessForm.GetPieceAt(xPosition, i) != this)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        protected void RemoveMoveButtons()
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
                if(p != null)
                {
                    UpdateBackColour(p.pieceButton, p.xPosition, p.yPosition);
                }
            }
        }

        protected void UpdateBackColour(Button button, int xPosition, int yPosition)
        {
            if ((xPosition + yPosition) % 2 != 0)
            {
                button.BackColor = Color.Peru;
            }
            else
            {
                button.BackColor = Color.BurlyWood;
            }
        }

        protected void MoveToSpace(object sender, MouseEventArgs e)
        {
            Button moveButton = sender as Button;
            xPosition = moveButton.Location.X / 100;
            yPosition = moveButton.Location.Y / 100;
            pieceButton.Location = moveButton.Location;
            UpdateBackColour(pieceButton, xPosition, yPosition);
            RemoveMoveButtons();
        }

        protected Tuple<bool, bool> IsMove(int xPosition, int yPosition)
        {
            bool pieceFound = false;
            bool isMove = false;
            if(chessForm.IsPieceAt(xPosition, yPosition))
            {
                pieceFound = true;
                if (chessForm.GetPieceAt(xPosition,yPosition).white != white)
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

        protected void CreateMoveButton(int xPosition, int yPosition)
        {
            Button moveButton = new Button();
            moveButton.Size = new Size(100, 100);
            moveButton.Location = new Point(xPosition * 100, yPosition * 100);
            moveButton.BackColor = Color.Green;
            moveButton.FlatStyle = FlatStyle.Flat;
            moveButton.FlatAppearance.BorderSize = 0;
            moveButton.MouseDown += new MouseEventHandler(MoveToSpace);
            chessForm.Controls.Add(moveButton);
            moveButton.BringToFront();
            movesCount++;
        }
        protected void InitializeButton()
        {
            pieceButton = new Button();
            pieceButton.Size = new Size(100, 100);
            pieceButton.Location = new Point(xPosition * 100, yPosition * 100);
            pieceButton.Image = image;
            UpdateBackColour(pieceButton, xPosition, yPosition);
            pieceButton.FlatStyle = FlatStyle.Flat;
            pieceButton.FlatAppearance.BorderSize = 0;
            pieceButton.MouseDown += new MouseEventHandler(PieceClick);
            pieceButton.BringToFront();
        }
    }
}
