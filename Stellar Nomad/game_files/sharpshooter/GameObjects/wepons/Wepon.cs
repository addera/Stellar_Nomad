using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace sharpshooter
{
    public abstract class Wepon
    {
        public Picture pic;
        public PointF location;
        public float bulletSpeed = 10;
        public int fireDelay = 300;
        public int timeSinceFire = 0;
        public float bulletStartDistance = 45f;
        public float faceingAngle = 180;
        public int radius;
        public String name = "N/A";
        public Boolean onGround;
        public Boolean isAutoGun = false;

        public Wepon(String image, PointF location)
        {
            this.pic = new Picture(image, location, 1, 1);
            this.location = location;
            this.radius = pic.bitmap.Width / 2;

        }

        public void Draw(Graphics g)
        {
            pic.angle = faceingAngle;
            pic.location.X = location.X - MainForm.veiwOffSet.X;
            pic.location.Y = location.Y - MainForm.veiwOffSet.Y;
            pic.Draw(g);
        }

        public void fire(Soldier playerFireing)
        {
            if (timeSinceFire < fireDelay)
            {
                return;
            }
            float Xcomponent = (float)Math.Cos(faceingAngle / 180f * Math.PI);
            float Ycomponent = -(float)Math.Sin(faceingAngle / 180f * Math.PI);
            Bullet bullet = createBullet(playerFireing);
            bullet.location.X = this.location.X + Xcomponent * bulletStartDistance;
            bullet.location.Y = this.location.Y + Ycomponent * bulletStartDistance;
            bullet.velocity.X = Xcomponent * bulletSpeed;
            bullet.velocity.Y = Ycomponent * bulletSpeed;
            timeSinceFire = 0;

        }

        public void Update(int time)
        {
            timeSinceFire += time;
            if (this.onGround == true && this.isTouching(MainForm.Player1))
            {
                if (this.isAutoGun == true)
                {
                    this.onGround = false;
                    MainForm.weponList.Remove(this);
                    MainForm.Player1.currentWepon = this;
                }
                else if (this.isAutoGun == false)
                {
                    this.onGround = false;
                    MainForm.weponList.Remove(this);
                    MainForm.Player1.currentWepon = this;
                    MainForm.Player1.autoGunSlot = this;
                }
                
            }
                
                
        }

        public abstract Bullet createBullet(Soldier playerFireing);

        public bool isTouching(Soldier s)
        {
            double distance = Math.Sqrt((s.location.X - this.location.X) * (s.location.X - this.location.X) + (s.location.Y - this.location.Y) * (s.location.Y - this.location.Y));
            return distance < s.radius + this.radius;
        }
    }
}
