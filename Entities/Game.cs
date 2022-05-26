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
        public Enemy enemy;
        public Missile FreeFlyMissile;
        public event Action<GameStage> StageChanged;
        private int[] MissileBounders = new int[4] { -500, 1736, -500, 2200 };

        public Game()
        {
            player = new Player();
            enemy = new Enemy();
        }

        public void LuchNewRocket()
        {
            FreeFlyMissile = player.Missile;
            player.LunchMissile();
        }

        public void CheckMissile()
        {
                if (player.Missile != null &&
                !Extensions.IsInCustomBounds(player.Missile.Cord, MissileBounders)) 
                    player.Missile = null;
            if (FreeFlyMissile != null &&
                !Extensions.IsInCustomBounds(FreeFlyMissile.Cord, MissileBounders))
                    FreeFlyMissile = null;
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