using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlyGame.Entities
{
    public class Game
    {
        private GameStage Stage = 0;
        public Player player;
        public List<Enemy> enemies = new List<Enemy>();
        public Missile FreeFlyMissile;
        public event Action<GameStage> StageChanged;
        private int[] MissileBounders = new int[4] { -500, 1736, -500, 2200 };

        private Point[] EnemySpawns = new Point[4] { new Point(-200, 400), new Point(500, -100),
                                                     new Point(2000, 400), new Point(600, 1700)};
        public Missile[] EnemyMissiles = new Missile[3] { null, null, null};
        private Random rnd = new Random();

        public Game()
        {
            player = new Player();
        }

        public void SpawnEnemy()
        {
            if (enemies.Count == 3) return;
            var number = GetEnemyNumber();
            if(number != -1)
                enemies.Add(new Enemy(EnemySpawns[rnd.Next(0,3)], number));
        }

        private int GetEnemyNumber()
        {
            for (var i = 0; i < 3; i++)
                if (EnemyMissiles[i] == null) return i;
            return -1;
        }

        public void UpdateEnemiesMissiles()
        {
            for(var i = 0; i < EnemyMissiles.Count(); i++)
            {
                CheckEnemiesMissile(EnemyMissiles[i], i);
                if(EnemyMissiles[i] != null) EnemyMissiles[i].MoveTo();

            }
        }

        public void UpdateEnemies()
        {
            foreach (var enemy in enemies)
            {
                if (player.Missile != null &&
                   Extensions.IsInObjectBounds(enemy.Cord, player.Missile.Cord))
                    enemy.MoveTo(player.Missile.Cord);
                else 
                    enemy.MoveTo(player.Cord);

                if (EnemyMissiles[enemy.Number] == null)
                {
                    enemy.LunchMissile(player.Cord);
                    EnemyMissiles[enemy.Number] = enemy.Missile;
                }
            }
        }

        public void CheckEnemiesMissile(Missile missile, int number)
        {
            if (missile == null) return;
            if (!Extensions.IsInCustomBounds(missile.Cord, MissileBounders))
                EnemyMissiles[number] = null;
        }

        public void LuchNewRocket()
        {
            FreeFlyMissile = player.Missile;
            player.LunchMissile();
        }

        public void CheckPlayerMissile()
        {
            if (player.Missile != null &&
                !Extensions.IsInCustomBounds(player.Missile.Cord, MissileBounders)) 
                    player.Missile = null;
            if (FreeFlyMissile != null &&
                !Extensions.IsInCustomBounds(FreeFlyMissile.Cord, MissileBounders))
                FreeFlyMissile = null;

            if (player.Missile != null)
                foreach (var enemy in enemies)
                {
                    if (Extensions.IsHitObject(player.Missile.Cord, enemy.Cord))
                    {
                        enemies.Remove(enemy);
                        player.Missile = null;
                        break;
                    }
                }
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