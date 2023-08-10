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
                whitePieces[i] = new Pawn(true);
                blackPieces[i] = new Pawn(false);
                chessBoard[6, i].Image = whitePieces[0].image;
                chessBoard[1,i].Image = blackPieces[0].image;
            }

            string pieceOrder = "rnbqkbnr";

            for (int i = 0; i < 8; i++)
            {
                switch (pieceOrder[i])
                {
                    case 'r':
                        whitePieces[i + 8] = new Rook(true);
                        blackPieces[i + 8] = new Rook(false);
                        break;

                    case 'n':
                        whitePieces[i + 8] = new Knight(true);
                        blackPieces[i + 8] = new Knight(false);
                        break;

                    case 'b':
                        whitePieces[i + 8] = new Bishop(true);
                        blackPieces[i + 8] = new Bishop(false);
                        break;

                    case 'q':
                        whitePieces[i + 8] = new Queen(true);
                        blackPieces[i + 8] = new Queen(false);
                        break;

                    case 'k':
                        whitePieces[i + 8] = new King(true);
                        blackPieces[i + 8] = new King(false);
                        break;
                }
                chessBoard[7, i].Image = whitePieces[i + 8].image;
                chessBoard[0, i].Image = blackPieces[i + 8].image;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BuildBoard();
            AddPieces();
        }
    }
}