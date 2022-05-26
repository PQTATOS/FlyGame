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
            Speed = 2;
            Health = 10;
            Cord = new Point(800, 100);
            //Sprite = Image.FromFile("C:\\Users\\vic\\source\\repos\\FlyGame\\Sprites\\battleship.png");
            Sprite = Properties.Resources.battleship;
        }

        public void LunchMissile()
        {
            Missile = new Missile(Cord);
        }
        
        public void MoveTo(int[] keys) //доделать
        {
            ChangeAngle(keys);

            if(xVel >= -5 && xVel <= 5 || keys.Skip(2).Any(x => x != 0))
                xVel += Speed * keys[3] - Speed * keys[2];
            if (yVel >= -5   || keys.Take(2).Any(x => x != 0))
                yVel += Speed * keys[1] - Speed * keys[0] + 1;
            if (IsInBounds(Cord.X + xVel, 1736)) Cord.X += xVel;
            if (IsInBounds(Cord.Y + yVel, 939)) Cord.Y += yVel;

        }

        private void ChangeAngle(int[] keys)
        {
            Angle += 10 * keys[2] - 10 * keys[3];
        }

        private bool IsInBounds(int cord, int border)
        {
            return cord > 0 && cord < border;
        }

        public void PlayAnimation(Graphics g)
        {
            g.DrawImage(Sprite, Cord.X, Cord.Y, new RectangleF(0,0,128,128), GraphicsUnit.Pixel);
            if (currentFrame == 3) currentFrame = 0;
           currentFrame++;
        }
    }
}
