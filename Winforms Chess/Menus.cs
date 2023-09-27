namespace Winforms_Chess
{
    internal class Menus
    {
        Form1 form;
        bool startAsWhite = true;

        Panel startMenu;
        Button startButton;
        Button choiceWhite;
        Button choiceBlack;
        Label choiceLabel;
        public Menus(Form1 form)
        {
            this.form = form;
        }

        public void CreateStartMenu()
        {
            startMenu = new Panel();
            startMenu.Size = new Size(500, 300);
            startMenu.Location = new Point(150, 100);
            startMenu.BackColor = Color.LightGray;
            startMenu.BorderStyle = BorderStyle.FixedSingle;

            startButton = new Button();
            startButton.Size = new Size(200, 40);
            startButton.Location = new Point(151, 200);
            startButton.Text = "Start Game";
            startButton.Font = new Font("Arial", 12, FontStyle.Bold);
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.BackColor = Color.ForestGreen;
            startButton.MouseDown += new MouseEventHandler(StartButtonClick);
            startMenu.Controls.Add(startButton);

            choiceWhite = new Button();
            choiceWhite.Size = new Size(100, 100);
            choiceWhite.Location = new Point(79, 90);
            choiceWhite.Image = new Bitmap("whitePieces\\whiteKing.png");
            choiceWhite.MouseDown += new MouseEventHandler(ColourChoiceClick);
            startMenu.Controls.Add(choiceWhite);

            choiceBlack = new Button();
            choiceBlack.Size = new Size(100, 100);
            choiceBlack.Location = new Point(325, 90);
            choiceBlack.Image = new Bitmap("blackPieces\\blackKing.png");
            choiceBlack.MouseDown += new MouseEventHandler(ColourChoiceClick);
            startMenu.Controls.Add(choiceBlack);

            choiceLabel = new Label();
            choiceLabel.Size = new Size(300, 50);
            choiceLabel.Location = new Point(100, 30);
            choiceLabel.Text = "Start with the White Pieces";
            choiceLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            choiceLabel.TextAlign = ContentAlignment.MiddleCenter;
            startMenu.Controls.Add(choiceLabel);

            form.Controls.Add(startMenu);
            form.Controls[form.Controls.Count - 1].BringToFront();
        }

        public void CreateEndMenu()
        {

        }

        public void CreatePromoteMenu()
        {

        }

        private void StartButtonClick(object sender, MouseEventArgs e)
        {
            form.StartGame(startAsWhite);
            startMenu.Hide();
        }

        private void ColourChoiceClick(object sender, MouseEventArgs e)
        {
            if (sender == choiceWhite)
            {
                startAsWhite = true;
                choiceLabel.Text = "Start with the White Pieces";
            }
            else if (sender == choiceBlack)
            {
                startAsWhite = false;
                choiceLabel.Text = "Start with the Black Pieces";
            }
        }
    }
}
