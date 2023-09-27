using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal class Pawn : Piece
    {
        public bool canEnPassant = false;
        public Pawn(bool white, int xPosition, int yPosition, BoardController chessBoard, Form1 chessForm) : base(white, xPosition, yPosition, chessBoard, chessForm)
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

        protected override List<Tuple<int,int>> PossibleMoves()
        {
            List<Tuple<int,int>> possibleMoves = new List<Tuple<int,int>>();
            if (white)
            {
                AddMove(possibleMoves, xPosition, yPosition - 1);
                AddMove(possibleMoves, xPosition, yPosition - 2);
                AddMove(possibleMoves, xPosition - 1, yPosition - 1);
                AddMove(possibleMoves, xPosition + 1, yPosition - 1);
            }
            else
            {
                AddMove(possibleMoves, xPosition, yPosition + 1);
                AddMove(possibleMoves, xPosition, yPosition + 2);
                AddMove(possibleMoves, xPosition - 1, yPosition + 1);
                AddMove(possibleMoves, xPosition + 1, yPosition + 1);
            }
            
            return possibleMoves;
        }

        protected override void MoveToSpace(object sender, MouseEventArgs e)
        {
            canEnPassant = false;
            Button moveButton = sender as Button;
            int yPosition = moveButton.Location.Y / 100;
            if(yPosition == this.yPosition + 2 && this.yPosition == 1 && !white)
            {
                canEnPassant = true;
            }
            else if(yPosition == this.yPosition - 2 && this.yPosition == 6 && white)
            {
                canEnPassant = true;
            }

            if(chessBoard.IsPieceAt(this.xPosition - 1, this.yPosition) && chessBoard.GetPieceAt(this.xPosition - 1, this.yPosition) is Pawn)
            {
                Pawn pawn = chessBoard.GetPieceAt(this.xPosition - 1, this.yPosition) as Pawn;
                if (pawn.white != white && pawn.canEnPassant)
                {
                    pawn.pieceButton.Enabled = false;
                    pawn.pieceButton.Visible = false;
                }
            }
            else if (chessBoard.IsPieceAt(this.xPosition + 1, this.yPosition) && chessBoard.GetPieceAt(this.xPosition + 1, this.yPosition) is Pawn)
            {
                Pawn pawn = chessBoard.GetPieceAt(this.xPosition + 1, this.yPosition) as Pawn;
                if(pawn.white != white && pawn.canEnPassant)
                {
                    pawn.pieceButton.Enabled = false;
                    pawn.pieceButton.Visible = false;
                }
            }
            base.MoveToSpace(sender, e);
        }

        protected override void SwapPieceLocation()
        {
            canEnPassant = false;
            base.SwapPieceLocation();
        }

        protected override bool LineOfSight(int xPosition, int yPosition)
        {
            if(this.yPosition != 6 && white && yPosition == this.yPosition - 2)
            {
                return false;
            }
            else if(this.yPosition != 1 && !white && yPosition == this.yPosition + 2)
            {
                return false;
            }
            else if(this.xPosition != xPosition)
            {
                if(!chessBoard.IsPieceAt(xPosition, yPosition))
                {
                    if(chessBoard.IsPieceAt(this.xPosition - 1, this.yPosition) && chessBoard.GetPieceAt(this.xPosition - 1, this.yPosition) is Pawn)
                    {
                        Pawn pawn = chessBoard.GetPieceAt(this.xPosition - 1, this.yPosition) as Pawn;
                        if(this.xPosition - 1 == xPosition)
                        {
                            return pawn.canEnPassant;
                        }
                    }
                    else if(chessBoard.IsPieceAt(this.xPosition + 1, this.yPosition) && chessBoard.GetPieceAt(this.xPosition + 1, this.yPosition) is Pawn)
                    {
                        Pawn pawn = chessBoard.GetPieceAt(this.xPosition + 1, this.yPosition) as Pawn;
                        if (this.xPosition + 1 == xPosition)
                        {
                            return pawn.canEnPassant;
                        }
                    }
                    return false;
                }
            }
            else if(this.xPosition == xPosition)
            {
                if (chessBoard.IsPieceAt(xPosition, yPosition))
                {
                    return false;
                }
            }
            return CardinalLineOfSight(xPosition, yPosition);
        }

        protected override void RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Console.WriteLine($"{xPosition},{yPosition}");
                Console.WriteLine(canEnPassant);
            }
        }
    }
}
