using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace sharpshooter
{
    public class Explosion
    {

        public Picture pic;
        public PointF location;
        public int life = 240;

        public Explosion(PointF location)
        {
            this.location = location;
            MainForm.explosionList.Add(this);
            this.pic = new Picture("Images/Explode.png", location, 6, 40);
        }

        public void Draw(Graphics g)
        {

            pic.location.X = location.X - MainForm.veiwOffSet.X;
            pic.location.Y = location.Y - MainForm.veiwOffSet.Y;
            pic.Draw(g);
        }

        public void Update(int time)
        {
            life -= time;
            if(life <= time)
            {

                MainForm.explosionList.Remove(this);
                return;
            }
            pic.Update(time);
        }
    }
}
