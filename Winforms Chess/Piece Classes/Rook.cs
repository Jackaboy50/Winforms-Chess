using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Winforms_Chess
{
    internal class Rook : Piece
    {
        public bool firstMovement = true;
        public Rook(bool white, int xPosition, int yPosition, Form1 chessForm) : base(white, xPosition, yPosition, chessForm)
        {
            if (white)
            {
                image = new Bitmap("whitePieces\\whiteRook.png");
            }
            else
            {
                image = new Bitmap("blackPieces\\blackRook.png");
            }
            InitializeButton();
        }
        protected override List<Tuple<int, int>> PossibleMoves()
        {
            List<Tuple<int, int>> possibleMoves = new List<Tuple<int, int>>();
            for (int i = 1; i < 8; i++)
            {
                AddMove(possibleMoves, xPosition + i, yPosition);
                AddMove(possibleMoves, xPosition - i, yPosition);
                AddMove(possibleMoves, xPosition, yPosition + i);
                AddMove(possibleMoves, xPosition, yPosition - i);
            }
            return possibleMoves;
        }

        protected override bool LineOfSight(int xPosition, int yPosition)
        {
            return CardinalLineOfSight(xPosition, yPosition);
        }

        protected override void SwapPieceLocation()
        {
            if (selectedPiece is King && selectedPiece.white == white)
            {
                Castle();
            }
            else
            {
                firstMovement = false;
                base.SwapPieceLocation();
            }
        }

        protected override void MoveToSpace(object sender, MouseEventArgs e)
        {
            firstMovement = false;
            base.MoveToSpace(sender, e);
        }

        protected override bool CausesCheck(int xPosition, int yPosition)
        {
            return base.CausesCheck(xPosition, yPosition);
        }

        private void Castle()
        {
            King king = selectedPiece as King;
            king.firstMovement = false;
            selectedPiece = king;
            int kingMove = 2;
            int rookMove = 2;
            if (selectedPiece.xPosition > xPosition)
            {
                kingMove = -kingMove;
                rookMove = -3;
            }
            selectedPiece.xPosition += kingMove;
            selectedPiece.pieceButton.Location = new Point(selectedPiece.xPosition * 100, pieceButton.Location.Y);
            xPosition -= rookMove;
            pieceButton.Location = new Point(xPosition * 100, pieceButton.Location.Y);
            pieceButton.Enabled = true;
            pieceButton.Visible = true;
        }
    }
}
