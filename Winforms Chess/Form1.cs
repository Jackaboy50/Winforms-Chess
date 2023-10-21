using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Winforms_Chess
{
    internal partial class Form1 : Form
    {
        public BoardController boardController;
        public Menus menus;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            Size = new Size(815, 835);
            boardController = new BoardController(this);
            menus = new Menus(this);

            boardController.BuildBoard();
            menus.CreateStartMenu();
        }

        public void StartGame(bool playerColour)
        {
            boardController.AddPieces(playerColour);
        }
    }
}