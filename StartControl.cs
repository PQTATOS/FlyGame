using FlyGame.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlyGame
{
    public partial class StartControl : UserControl
    {
        public Game game;
        public StartControl()
        {
            InitializeComponent();
        }

        public void GameSetUp(Game Game)
        {
            this.game = Game;
            button1.Click += StartButton;
        }

        private void StartButton(object sender, EventArgs e)
        {
            game.Start(GameStage.Battle);
        }

        private void StartControl_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
