using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FlyGame.Entities
{
    public class Enemy : Battleship
    {
        public int Number;
        private int currentFrame = 0;
        public Enemy(Point cord, int number)
        {
            Speed = 5;
            Sprite = Properties.Resources.enemy;
            Cord = cord;
            Number = number;
        }

        public void MoveTo(Point playerCord)
        {
            var x = playerCord.X - Cord.X;
            var y = playerCord.Y - Cord.Y;
            var distance = Math.Sqrt(x*x + y*y);
            var diration = Math.Atan2(y,x);

            if (distance > 500)
            {
                Cord.X += (int)(Speed * Math.Cos(diration));
                Cord.Y += (int)(Speed * Math.Sin(diration));
            }
            if(distance < 400)
            {
                Cord.X -= (int)(Speed * Math.Cos(diration));
                Cord.Y -= (int)(Speed * Math.Sin(diration));
            }
        }

        public void LunchMissile(Point playerCord)
        {
            var angel = Math.Atan2(playerCord.X - Cord.X, Cord.Y - playerCord.Y) * 180 / Math.PI;
            Missile = new Missile(Cord, angel, Properties.Resources.enemyMissile);
        }

        public void DrawEnemy(Graphics g)
        {
            g.DrawImage(Sprite, Cord.X, Cord.Y, new RectangleF(64 * currentFrame, 0, 64, 64), GraphicsUnit.Pixel);
            if (currentFrame == 3) currentFrame = 0;
            currentFrame++;
        }
    }
}
