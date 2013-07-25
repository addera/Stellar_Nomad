using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace sharpshooter
{
    public class RapidGun : Wepon
    {
        public RapidGun(PointF location): base("Images/RapidGun.png", location)
        {
            this.bulletSpeed = 15f;
            this.bulletStartDistance = 15f;
            this.fireDelay = 50;
            this.name = "Rapid Gun";
        }

        public override Bullet createBullet(Soldier playerFireing)
        {
            //return new Bullet("Images/Bullet1.png", playerFireing, new PointF());

            Bullet b = new Bullet("Images/Bullet1.png", playerFireing, new PointF());
            b.damage = 1;
            return b;
        }
    }
}
