using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winforms_Chess
{
    internal class BoardController
    {
        Form1 form;
        Button[,] chessBoard = new Button[8, 8];
        Piece[] whitePieces = new Piece[16];
        Piece[] blackPieces = new Piece[16];
        public Piece[] allPieces = new Piece[32];
        public BoardController(Form1 form)
        {
            this.form = form;
        }
        public void BuildBoard()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    chessBoard[x, y] = new Button();
                }
            }

            bool colourFlip = false;
            int xOffset = 0;
            int yOffset = 0;
            foreach (Button button in chessBoard)
            {
                if (xOffset == 8)
                {
                    xOffset = 0;
                    yOffset++;
                    colourFlip = !colourFlip;
                }
                button.Location = new Point(xOffset * 100, yOffset * 100);
                button.Size = new Size(100, 100);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.SendToBack();
                button.Enabled = false;
                if (!colourFlip)
                {
                    button.BackColor = Color.BurlyWood;
                }
                else
                {
                    button.BackColor = Color.Peru;
                }

                if (xOffset == 0)
                {
                    CreateNumberLabel(xOffset, yOffset, colourFlip);
                }
                if (yOffset == 7)
                {
                    CreateLetterLabel(xOffset, yOffset, colourFlip);
                }
                colourFlip = !colourFlip;
                xOffset++;

                form.Controls.Add(button);
            }
        }

        private void CreateNumberLabel(int xOffset, int yOffset, bool colourFlip)
        {
            Label tileNumber = new Label();
            tileNumber.Location = new Point(xOffset * 100, yOffset * 100);
            tileNumber.Text = (yOffset + 1).ToString();
            tileNumber.Size = new Size(20, 20);
            tileNumber.Font = new Font("Arial", 12, FontStyle.Bold);
            if (!colourFlip)
            {
                tileNumber.ForeColor = Color.Peru;
                tileNumber.BackColor = Color.BurlyWood;
            }
            else
            {
                tileNumber.ForeColor = Color.BurlyWood;
                tileNumber.BackColor = Color.Peru;
            }
            form.Controls.Add(tileNumber);
            form.Controls[form.Controls.Count - 1].BringToFront();
        }

        private void CreateLetterLabel(int xOffset, int yOffset, bool colourFlip)
        {
            Label tileLetter = new Label();
            tileLetter.Location = new Point((xOffset * 100) + 80, (yOffset * 100) + 75);
            tileLetter.Text = ((char)(104 - xOffset)).ToString();
            tileLetter.Size = new Size(20, 20);
            tileLetter.Font = new Font("Arial", 12, FontStyle.Bold);
            if (!colourFlip)
            {
                tileLetter.ForeColor = Color.Peru;
                tileLetter.BackColor = Color.BurlyWood;
            }
            else
            {
                tileLetter.ForeColor = Color.BurlyWood;
                tileLetter.BackColor = Color.Peru;
            }
            form.Controls.Add(tileLetter);
            form.Controls[form.Controls.Count - 1].BringToFront();
        }

        public void AddPieces()
        {
            for (int i = 0; i < 8; i++)
            {
                whitePieces[i] = new Pawn(true, i, 6, form);
                blackPieces[i] = new Pawn(false, i, 1, form);
                form.Controls.Add(whitePieces[i].pieceButton);
                form.Controls.Add(blackPieces[i].pieceButton);
            }

            string pieceOrder = "rnbqkbnr";
            for (int i = 0; i < 8; i++)
            {
                switch (pieceOrder[i])
                {
                    case 'r':
                        whitePieces[i + 8] = new Rook(true, i, 7, form);
                        blackPieces[i + 8] = new Rook(false, i, 0, form);
                        break;

                    case 'n':
                        whitePieces[i + 8] = new Knight(true, i, 7, form);
                        blackPieces[i + 8] = new Knight(false, i, 0, form);
                        break;

                    case 'b':
                        whitePieces[i + 8] = new Bishop(true, i, 7, form);
                        blackPieces[i + 8] = new Bishop(false, i, 0, form);
                        break;

                    case 'q':
                        whitePieces[i + 8] = new Queen(true, i, 7, form);
                        blackPieces[i + 8] = new Queen(false, i, 0, form);
                        break;

                    case 'k':
                        whitePieces[i + 8] = new King(true, i, 7, form);
                        blackPieces[i + 8] = new King(false, i, 0, form);
                        break;
                }
                form.Controls.Add(whitePieces[i + 8].pieceButton);
                form.Controls.Add(blackPieces[i + 8].pieceButton);
                allPieces = whitePieces.Concat(blackPieces).ToArray();
            }
        }

        public bool IsPieceAt(int xPosition, int yPosition)
        {
            for (int i = 0; i < allPieces.Length; i++)
            {
                if (allPieces[i].xPosition == xPosition && allPieces[i].yPosition == yPosition)
                {
                    if (allPieces[i].pieceButton.Visible == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Piece GetPieceAt(int xPosition, int yPosition)
        {
            for (int i = 0; i < allPieces.Length; i++)
            {
                if (allPieces[i].xPosition == xPosition && allPieces[i].yPosition == yPosition)
                {
                    return allPieces[i];
                }
            }
            return null;
        }
        
    }
}
