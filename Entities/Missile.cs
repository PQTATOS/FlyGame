using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FlyGame.Entities
{
    public class Missile
    {
        int Speed = 15,
            Damage;
        Image Sprite;
        public Point Cord;
        private int Angle = 0;
        int CurrentFrame = 0;

        public Missile(Point point)
        {
            Angle = 0;
            Cord = new Point(point.X + 15, point.Y - 10);

            Sprite = Properties.Resources.missile;
        }

        public void MoveTo(int[] keys)
        {
            ChangeAngle(keys);
            var RadAngle = ((Angle + 90) * Math.PI)/ 180;
            Cord.X -= (int)(Speed * Math.Cos(RadAngle));
            Cord.Y -= (int)(Speed * Math.Sin(RadAngle));
        }
        public void MoveTo()
        {
            var RadAngle = ((Angle + 90) * Math.PI) / 180;
            Cord.X -= (int)(Speed * Math.Cos(RadAngle));
            Cord.Y -= (int)(Speed * Math.Sin(RadAngle));
        }

        private void ChangeAngle(int[] keys)
        {
            Angle += 5 * keys[1] - 5 * keys[0];
        }

        public void DrawMissile(Graphics g)
        {
            g.TranslateTransform((Cord.X+10), (Cord.Y+35));
            g.RotateTransform(Angle);
            g.TranslateTransform(-(Cord.X + 10), -(Cord.Y + 35));



            g.DrawImage(Sprite, Cord.X, Cord.Y, new RectangleF(20 *CurrentFrame, 0, 20, 71), GraphicsUnit.Pixel);
            if (CurrentFrame == 3) CurrentFrame = -1;
            CurrentFrame++;

            g.TranslateTransform((Cord.X + 10), (Cord.Y + 35));
            g.RotateTransform(-Angle);
            g.TranslateTransform(-(Cord.X + 10), -(Cord.Y + 35));
        }
    }
}
