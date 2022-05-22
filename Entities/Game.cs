using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlyGame.Entities
{
    public class Game
    {
        private GameStage Stage = 0;
        public Player player;
        private Enemy[] enemies;
        public Missile FreeFlyMissile;
        public event Action<GameStage> StageChanged;

        public Game()
        {
            player = new Player();
        }
        public void LuchNewRocket()
        {
            FreeFlyMissile = player.Missile;
            player.LunchMissile();
        }
        private void ChangeStage(GameStage stage)
        {
            this.Stage = stage;
            StageChanged?.Invoke(Stage);
        }
        public void Start(GameStage stage)
        {
            ChangeStage(stage);
        }
    }
}