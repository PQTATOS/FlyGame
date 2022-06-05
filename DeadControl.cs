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
            button1.Click += Restart;
        }

        private void Restart(object sender, EventArgs e)
        {
            game.Reset();
            game.Start(GameStage.Battle);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            g.DrawString("Ваш результат: " + game.Score, new Font("Arial", 32), Brushes.White, new Point(628, 269));
        }
    }
}
