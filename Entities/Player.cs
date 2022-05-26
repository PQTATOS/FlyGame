using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FlyGame.Entities
{
    public class Player : Battleship
    {
        int currentFrame = 0,
            Angle = 0,
            xVel = 0,
            yVel = 0;
        public Player()
        {
            Speed = 4;
            Cord = new Point(800, 200);
            Sprite = Properties.Resources.battleship;
        }

        public void LunchMissile()
        {
            Missile = new Missile(Cord);
        }
        
        public void MoveTo(int[] keys) 
        {
            if (xVel < 8 && xVel > -8) xVel += Speed * keys[3] - Speed * keys[2];
            else xVel -= xVel / Math.Abs(xVel);

            if (yVel < 10 && yVel > -10) yVel += Speed * keys[1] - Speed * keys[0] + 2;
            else yVel -= yVel / Math.Abs(yVel) * 2;

            Cord.Y += yVel;
            Cord.X += xVel;

            var bounds = Extensions.IsInGameBounds(Cord);

            if (!bounds.Item1) Cord.X -= xVel;
            if (!bounds.Item2) Cord.Y -= yVel;
        }
        private Tuple<bool, bool> IsInBounds(Point cord)
        {
            var x = cord.X >= -64 && cord.X + 64 <= 1736;
            var y = cord.Y >= -64 && cord.Y + 64 <= 939;
            return Tuple.Create(x, y);
        }
        public void PlayAnimation(Graphics g)
        {
            g.DrawImage(Sprite, Cord.X, Cord.Y, new RectangleF(0,0,128,128), GraphicsUnit.Pixel);
            if (currentFrame == 3) currentFrame = 0;
           currentFrame++;
        }
    }
}
