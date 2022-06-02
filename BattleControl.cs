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
    public partial class BattleControl : UserControl
    {
        Game game;
        Timer gameTimer;
        bool IsPause = true;
        int[] PlayerKeys = new int[4] {0, 0, 0, 0 };
        int[] PlayerMissileKeys = new int[3] { 0, 0, 0};
        

        public BattleControl()
        {
            InitializeComponent(); 
            DoubleBuffered = true;

            gameTimer = new Timer();
            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);
            PreviewKeyDown += new PreviewKeyDownEventHandler(OnPreviewKeyDown);

            gameTimer.Interval = 30;
            gameTimer.Tick += new EventHandler(Update);
            gameTimer.Start();
        }

        public void GameSetUp(Game Game)
        {
            game = Game;
        }

        public void Update(object sender, EventArgs e)
        {
            if (IsPause) return;

            game.SpawnEnemy();

            game.player.MoveTo(PlayerKeys);

            if (game.player.Missile != null)  game.player.Missile.MoveTo(PlayerMissileKeys);
            if (game.FreeFlyMissile != null) game.FreeFlyMissile.MoveTo();
            game.CheckPlayerMissile();

            game.UpdateEnemies();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            

            game.player.PlayAnimation(g);
            if (game.player.Missile != null) game.player.Missile.DrawMissile(g);
            if (game.FreeFlyMissile != null) game.FreeFlyMissile.DrawMissile(g);
            foreach (var enemy in game.enemies)
                enemy.DrawEnemy(g);
             
        }

        //CONTROLS
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.W):
                    PlayerKeys[0] = 0;
                    break;
                case (Keys.S):
                    PlayerKeys[1] = 0;
                    break;
                case (Keys.A):
                    PlayerKeys[2] = 0;
                    break;
                case (Keys.D):
                    PlayerKeys[3] = 0;
                    break;
                case (Keys.Left):
                    PlayerMissileKeys[0] = 0;
                    break;
                case (Keys.Right):
                    PlayerMissileKeys[1] = 0;
                    break;
            }
        }

        private void OnPress(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case (Keys.W):
                    PlayerKeys[0] = 1;
                    break;
                case (Keys.S):
                    PlayerKeys[1] = 1;
                    break;
                case (Keys.A):
                    PlayerKeys[2] = 1;
                    break;
                case (Keys.D):
                    PlayerKeys[3] = 1;
                    break;
                case (Keys.Left):
                    PlayerMissileKeys[0] = 1;
                    break;
                case (Keys.Right):
                    PlayerMissileKeys[1] = 1;
                    break;
                case (Keys.Space):
                    game.LuchNewRocket();
                    break;
                case (Keys.Escape):
                    IsPause = !IsPause;
                    break;
            }    
        }

        private void OnPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
                case Keys.Left:
                    e.IsInputKey = true;
                    break;
                case Keys.Escape:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void BattleControl_Load(object sender, EventArgs e)
        {

        }
    }
}
