namespace Winforms_Chess
{
    public partial class Form1 : Form
    {
        Button[,] chessBoard = new Button[8,8];
        Piece[] whitePieces = new Piece[16];
        Piece[] blackPieces = new Piece[16];
        public Form1()
        {
            InitializeComponent();
        }

        private void BuildBoard()
        {
            for(int x = 0; x < 8; x++)
            {
                for(int y = 0; y < 8; y++)
                {
                    chessBoard[x,y] = new Button();
                }
            }

            bool colourFlip = false;
            int xOffset = 0;
            int yOffset = 0;
            foreach(Button button in chessBoard)
            {
                if(xOffset == 8)
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
                colourFlip = !colourFlip;
                xOffset++;

                Controls.Add(button);
            }
        }

        private void AddPieces()
        {
            for(int i = 0; i < 8; i++)
            {
                whitePieces[i] = new Pawn(true, i, 6);
                blackPieces[i] = new Pawn(false, i, 1);
                Controls.Add(whitePieces[i].pieceButton);
                Controls.Add(blackPieces[i].pieceButton);
            }

            string pieceOrder = "rnbqkbnr";
            for (int i = 0; i < 8; i++)
            {
                switch (pieceOrder[i])
                {
                    case 'r':
                        whitePieces[i + 8] = new Rook(true, i, 7);
                        blackPieces[i + 8] = new Rook(false, i, 0);
                        break;

                    case 'n':
                        whitePieces[i + 8] = new Knight(true, i, 7);
                        blackPieces[i + 8] = new Knight(false, i, 0);
                        break;

                    case 'b':
                        whitePieces[i + 8] = new Bishop(true, i, 7);
                        blackPieces[i + 8] = new Bishop(false, i, 0);
                        break;

                    case 'q':
                        whitePieces[i + 8] = new Queen(true, i, 7);
                        blackPieces[i + 8] = new Queen(false, i, 0);
                        break;

                    case 'k':
                        whitePieces[i + 8] = new King(true, i, 7);
                        blackPieces[i + 8] = new King(false, i, 0);
                        break;
                }
                Controls.Add(whitePieces[i + 8].pieceButton);
                Controls.Add(blackPieces[i + 8].pieceButton);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddPieces();
            BuildBoard();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}