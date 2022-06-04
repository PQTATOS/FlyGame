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
    public partial class DeadControl : UserControl
    {
        Game game;
        public DeadControl()
        {
            InitializeComponent();
        }

        public void GameSetUp(Game Game)
        {
            game = Game;
            game.Reset();
            button1.Click += Restart;
        }

        private void Restart(object sender, EventArgs e)
        {
            game.Start(GameStage.Battle);
        }
    }
}
