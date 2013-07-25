using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace sharpshooter
{
    public class AutoGun : Wepon
    {

        public AutoGun(PointF location) : base("Images/AutoGun.png", location)
        {
            this.bulletSpeed = 10;
            this.fireDelay = 100;
            this.bulletStartDistance = 40f;
            this.name = "Auto Gun";
            
            this.isAutoGun = true;
        }
        
        public override Bullet createBullet(Soldier playerFireing)
        {
            Bullet b = new Bullet("Images/Bullet1.png", playerFireing, new PointF());
            b.damage = 1;
            return b;
        }
    }
}
