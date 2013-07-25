using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace sharpshooter
{
    public class EnemyPistol : Wepon
    {


        public EnemyPistol(PointF location): base("Images/Pistol.png", location)
        {
            this.bulletSpeed = 11f;
            this.bulletStartDistance = 15f;
            this.fireDelay = 200;
            this.name = "Pistol";
        }

        public override Bullet createBullet(Soldier playerFireing)
        {
            Bullet b = new Bullet("Images/Bullet1.png", playerFireing, new PointF());
            b.damage = 4;
            return b;
        }

    }
}
