using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace sharpshooter
{
    public class Bullet     // bang
    {
        public Picture pic;
        public PointF location;
        public PointF velocity;
        public float bulletLife = 0.8f;  // bullet life
        public int radius;
        public int damage;
        Soldier parent;

        public Bullet(String name, Soldier s, PointF location)
        {
            pic = new Picture(name, location, 12, 25);
            velocity = new PointF();
            this.location = location;
            MainForm.bulletList.Add(this);
            radius = pic.bitmap.Width / 2;
            this.parent = s;
        }

        public virtual void Draw(Graphics g)
        {
            pic.location.X = location.X - MainForm.veiwOffSet.X;
            pic.location.Y = location.Y - MainForm.veiwOffSet.Y;
            pic.Draw(g); 
        }

        public bool isTouching(Soldier s)
        {
            double distance = Math.Sqrt((s.location.X - this.location.X) * (s.location.X - this.location.X) + (s.location.Y - this.location.Y) * (s.location.Y - this.location.Y));
            return distance < s.radius + this.radius;
        }

        public virtual void Update(int time)
        {
            
            bulletLife -= (float)time / 1000f;
            if (bulletLife <= 0)
            {
                MainForm.bulletList.Remove(this);
            }
            if (parent == MainForm.Player1)
            {

                for (int i = 0; i < MainForm.enemyList.Count; i++)
                {
                    if (this.isTouching(MainForm.enemyList[i]))
                    {

                        MainForm.enemyList[i].takeDamage(this.damage);
                        MainForm.bulletList.Remove(this);
                    }
                }
                pic.Update(time);
            }
            for (int j = 0; j < MainForm.autoGunnerList.Count; j++)
            {
                if (parent == MainForm.autoGunnerList[j])
                    {
                        for (int i = 0; i < MainForm.enemyList.Count; i++)
                        {
                            if (this.isTouching(MainForm.enemyList[i]))
                            {

                                MainForm.enemyList[i].takeDamage(this.damage);
                                MainForm.bulletList.Remove(this);
                            }
                        }
                    }
            }
            for(int i = 0; i < MainForm.enemyList.Count; i++)
            {
                if (parent == MainForm.enemyList[i])
                {

                    if (this.isTouching(MainForm.Player1) && !MainForm.Player1.killed)
                    {
                        MainForm.Player1.takeDamage(this.damage);
                        MainForm.bulletList.Remove(this);
                    }
                }

            }
            foreach(Wall w in MainForm.wallList)
            {
                if (this.isTouchingWall(w))
                {
                    this.pushBack();
                    PointF normal = w.normalAtNearestPoint(this.location);
                    this.bounceFrom(normal);
                }
            }


            move();
        }

        public virtual void move()
        {
            location.X += velocity.X;
            location.Y += velocity.Y;
        }

        public bool isTouchingWall(Wall w)
        {
            PointF nearestPoint = w.pointNearestTo(this.location);
            float distance = (float)Math.Sqrt((nearestPoint.X - this.location.X) * (nearestPoint.X - this.location.X) + (nearestPoint.Y - this.location.Y) * (nearestPoint.Y - this.location.Y));
            if (distance < this.radius)
            {
                return (true);
            }
            else
            {
                return false;
            }

        }
        public void pushBack()
        {
            this.location.X -= this.velocity.X;
            this.location.Y -= this.velocity.Y;
        }

        public void bounceFrom(PointF normal)
        {
            PointF r;
            float b = (velocity.X * normal.X + velocity.Y * normal.Y);
            b *= 2;
            r = new PointF(this.velocity.X - normal.X * b, this.velocity.Y - normal.Y * b);
            this.velocity.X = r.X;
            this.velocity.Y = r.Y;
        }
    }
}
