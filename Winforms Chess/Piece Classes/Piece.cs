﻿namespace Winforms_Chess
{
    internal abstract class Piece
    {
        private static int movesCount = 0;
        public int xPosition { get; set; }
        public int yPosition { get; set; }
        protected int initialXPosition;
        protected int initialYPosition;
        public bool white { get; private set; }
        public bool isSelected = false;
        protected static bool whiteAtBottom;
        public static Piece selectedPiece { get; protected set; }

        protected BoardController chessBoard;
        protected Form1 chessForm;
        public Button pieceButton { get; protected set; }
        protected Image image;
       

        public Piece(bool white, int xPosition, int yPosition, BoardController chessBoard, Form1 chessForm)
        {
            this.white = white;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.chessBoard = chessBoard;
            this.chessForm = chessForm;

            initialXPosition = this.xPosition;
            initialYPosition = this.yPosition;
        }

        public static void SetWhitePosition(bool whiteOnBottom)
        {
            whiteAtBottom = whiteOnBottom;
        }
        protected abstract List<Tuple<int, int>> PossibleMoves();
        protected abstract bool LineOfSight(int xPosition, int yPosition);

        protected void AddMove(List<Tuple<int,int>> possibleMoves, int xPosition, int yPosition)
        {
            if(xPosition < 8 && xPosition > -8 && yPosition < 8 && yPosition > -8)
            {
                possibleMoves.Add(new Tuple<int, int>(xPosition, yPosition));
            }
        }
        protected void PieceClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                return;
            }

            if (!isSelected)
            {
                selectedPiece = this;
                bool stopsCheck = false;
                RemoveMoveButtons(); 
                foreach (Tuple<int, int> position in PossibleMoves())
                {
                    if (CausesCheck(position.Item1, position.Item2))
                    {
                        continue;
                    }
                    else if (InCheck() && LineOfSight(position.Item1, position.Item2))
                    {
                        stopsCheck = true;
                        DrawMove(position);
                        continue;
                    }
                    DrawMove(position);
                }
                if (!stopsCheck && InCheck())
                {
                    DenyMove();
                }
            }
            else
            {
                if(pieceButton.BackColor == Color.Green)
                {
                    RemoveMoveButtons();
                    pieceButton.Enabled = false;
                    pieceButton.Visible = false;
                    SwapPieceLocation();
                    UpdateBackColour(selectedPiece.pieceButton, selectedPiece.xPosition, selectedPiece.yPosition);
                }
            }
        }

        protected void DrawMove(Tuple<int, int> position)
        {
            Tuple<bool, bool> moveCheck = IsMove(position.Item1, position.Item2);
            if (moveCheck.Item1 && moveCheck.Item2 && LineOfSight(position.Item1, position.Item2))
            {
                chessBoard.GetPieceAt(position.Item1, position.Item2).pieceButton.BackColor = Color.Green;
                chessBoard.GetPieceAt(position.Item1, position.Item2).isSelected = true;
            }
            else if (moveCheck.Item1 && !moveCheck.Item2 && LineOfSight(position.Item1, position.Item2))
            {
                CreateMoveButton(position.Item1, position.Item2);
            }
        }

        protected bool InCheck()
        {
            King king;
            if(white)
            {
                king = chessBoard.allPieces[12] as King;
            }
            else
            {
                king = chessBoard.allPieces[28] as King;
            }

            foreach(Piece piece in chessBoard.allPieces)
            {
                if (!piece.pieceButton.Enabled)
                {
                    continue;
                }
                if(piece.white == white)
                {
                    continue;
                }
                foreach(Tuple<int, int> position in piece.PossibleMoves())
                {
                    if(!piece.LineOfSight(king.xPosition, king.yPosition))
                    {
                        break;
                    }
                    if(position.Item1 != king.xPosition || position.Item2 != king.yPosition)
                    {
                        continue;
                    }
                    Tuple<bool, bool> moveCheck = piece.IsMove(position.Item1, position.Item2);
                    if(moveCheck.Item1)
                    {
                        return true;
                    }
                    break;
                }
            }
            return false;
        }

        protected virtual bool CausesCheck(int xPosition, int yPosition)
        {
            bool causesCheck = false;
            int oldX = this.xPosition;
            int oldY = this.yPosition;

            if(chessBoard.IsPieceAt(xPosition, yPosition))
            {
                chessBoard.GetPieceAt(xPosition, yPosition).pieceButton.Enabled = false;
            }

            this.xPosition = xPosition;
            this.yPosition = yPosition;
            causesCheck = InCheck();
            
            this.xPosition = oldX;
            this.yPosition = oldY;
            if (chessBoard.IsPieceAt(xPosition, yPosition))
            {
                chessBoard.GetPieceAt(xPosition, yPosition).pieceButton.Enabled = true;
            }
            return causesCheck;
        }

        protected virtual void SwapPieceLocation()
        {
            selectedPiece.xPosition = xPosition;
            selectedPiece.yPosition = yPosition;
            selectedPiece.pieceButton.Location = pieceButton.Location;
            if(selectedPiece is Pawn)
            {
                selectedPiece.CheckPromote();
            }
        }

        protected virtual void CheckPromote()
        {
            if(!(this is Pawn))
            {
                return;
            }
        }

        protected void DenyMove()
        {
            RemoveMoveButtons();
            foreach(Piece p in chessBoard.allPieces)
            {
                if(p != null && p is King && p.white == white)
                {
                    p.pieceButton.BackColor = Color.Red;
                }
            }
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

            foreach(Piece p in chessBoard.allPieces)
            {
                if(p != null)
                {
                    p.isSelected = false;
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

        protected virtual void MoveToSpace(object sender, MouseEventArgs e)
        {
            Button moveButton = sender as Button;
            xPosition = moveButton.Location.X / 100;
            yPosition = moveButton.Location.Y / 100;
            pieceButton.Location = moveButton.Location;
            UpdateBackColour(pieceButton, xPosition, yPosition);
            RemoveMoveButtons();
        }

        protected virtual Tuple<bool, bool> IsMove(int xPosition, int yPosition)
        {
            bool isMove = false;
            bool pieceFound = false;
            if(chessBoard.IsPieceAt(xPosition, yPosition))
            {
                pieceFound = true;
                if (chessBoard.GetPieceAt(xPosition, yPosition).white != white)
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
            pieceButton.MouseDown += new MouseEventHandler(RightClick);
            pieceButton.BringToFront();
        }

        protected virtual void RightClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                Console.WriteLine($"{xPosition},{yPosition}");
            }
        }

        protected bool CardinalLineOfSight(int xPosition, int yPosition)
        {
            if (this.xPosition > xPosition && this.yPosition == yPosition)
            {
                for (int i = xPosition + 1; i < this.xPosition; i++)
                {
                    if (chessBoard.IsPieceAt(i, yPosition) && chessBoard.GetPieceAt(i, yPosition) != this)
                    {
                        return false;
                    }
                }
            }

            if (this.xPosition < xPosition && this.yPosition == yPosition)
            {
                for (int i = xPosition - 1; i > this.xPosition; i--)
                {
                    if (chessBoard.IsPieceAt(i, yPosition) && chessBoard.GetPieceAt(i, yPosition) != this)
                    {
                        return false;
                    }
                }
            }

            if (this.xPosition == xPosition && this.yPosition < yPosition)
            {
                for (int i = yPosition - 1; i > this.yPosition; i--)
                {
                    if (chessBoard.IsPieceAt(xPosition, i) && chessBoard.GetPieceAt(xPosition, i) != this)
                    {
                        return false;
                    }
                }
            }

            if (this.xPosition == xPosition && this.yPosition > yPosition)
            {
                for (int i = yPosition + 1; i < this.yPosition; i++)
                {
                    if (chessBoard.IsPieceAt(xPosition, i) && chessBoard.GetPieceAt(xPosition, i) != this)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        protected bool DiagonalLineOfSight(int xPosition, int yPosition)
        {
            if (this.xPosition < xPosition && this.yPosition < yPosition)
            {
                for (int i = 1; i < xPosition - this.xPosition; i++)
                {
                    if (chessBoard.IsPieceAt(xPosition - i, yPosition - i) && chessBoard.GetPieceAt(xPosition - i, yPosition - i) != this)
                    {
                        return false;
                    }
                }
            }

            if (this.xPosition > xPosition && this.yPosition < yPosition)
            {
                for (int i = 1; i < this.xPosition - xPosition; i++)
                {
                    if (chessBoard.IsPieceAt(xPosition + i, yPosition - i) && chessBoard.GetPieceAt(xPosition + i, yPosition - i) != this)
                    {
                        return false;
                    }
                }
            }

            if (this.xPosition > xPosition && this.yPosition > yPosition)
            {
                for (int i = 1; i < this.xPosition - xPosition; i++)
                {
                    if (chessBoard.IsPieceAt(xPosition + i, yPosition + i) && chessBoard.GetPieceAt(xPosition + i, yPosition + i) != this)
                    {
                        return false;
                    }
                }
            }

            if (this.xPosition < xPosition && this.yPosition > yPosition)
            {
                for (int i = 1; i < xPosition - this.xPosition; i++)
                {
                    if (chessBoard.IsPieceAt(xPosition - i, yPosition + i) && chessBoard.GetPieceAt(xPosition - i, yPosition + i) != this)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
