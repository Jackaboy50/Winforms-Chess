using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
    internal class King : Piece
    {
        public bool firstMovement = true;
        public King(bool white, int xPosition, int yPosition, BoardController chessBoard, Form1 chessForm) : base(white, xPosition, yPosition, chessBoard, chessForm)
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
        protected override List<Tuple<int, int>> PossibleMoves()
        {
            List<Tuple<int, int>> possibleMoves = new List<Tuple<int, int>>();
            for(int i = -1; i < 2; i++)
            {
                AddMove(possibleMoves, xPosition - 1, yPosition + i);
                AddMove(possibleMoves, xPosition + 1, yPosition - i);
            }
            AddMove(possibleMoves, xPosition, yPosition - 1);
            AddMove(possibleMoves, xPosition, yPosition + 1);

            if (firstMovement)
            {
                AddMove(possibleMoves, xPosition + 3, yPosition);
                AddMove(possibleMoves, xPosition - 4, yPosition);
            }
            return possibleMoves;
        }

        protected override bool LineOfSight(int xPosition, int yPosition)
        {
            if(firstMovement && (xPosition > this.xPosition + 1 || xPosition < this.xPosition - 1))
            {
                return CardinalLineOfSight(xPosition, yPosition);
            }
            return true;
        }

        protected override void MoveToSpace(object sender, MouseEventArgs e)
        {
            firstMovement = false;
            base.MoveToSpace(sender, e);
        }

        protected override Tuple<bool, bool> IsMove(int xPosition, int yPosition)
        {
            bool pieceFound = false;
            bool isMove = false;
            
            if (chessBoard.IsPieceAt(xPosition, yPosition))
            {
                pieceFound = true;
                if (chessBoard.GetPieceAt(xPosition, yPosition).white != white)
                {
                    isMove = true;
                }
                else if (firstMovement && chessBoard.GetPieceAt(xPosition, yPosition) is Rook && chessBoard.GetPieceAt(xPosition, yPosition).white == white)
                {
                    Rook rook = chessBoard.GetPieceAt(xPosition, yPosition) as Rook;
                    if(rook.firstMovement == true)
                    {
                        isMove = true;
                    }
                }
            }
            if (!pieceFound)
            {
                isMove = true;
            }
            return new Tuple<bool, bool>(isMove, pieceFound);
        }
    }
}
