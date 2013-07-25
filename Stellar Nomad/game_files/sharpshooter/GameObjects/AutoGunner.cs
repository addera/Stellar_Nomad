using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace sharpshooter
{
    public class AutoGunner : Soldier
    {


        public AutoGunner(PointF location) : base("Images/AutoGunner.png", location)
        {
            this.currentWepon = new RapidGun(this.location);
            this.isAutoGunner = true;
            MainForm.autoGunnerList.Add(this);
            this.fireing = true;
            this.moveSpeed = 0;

        }

        public override void Update(int time)
        {
            base.Update(time);
            for (int i = 0; i < MainForm.enemyList.Count; i++)
            {
                float distence = (float)Math.Sqrt((MainForm.enemyList[i].location.X - this.location.X) * (MainForm.enemyList[i].location.X - this.location.X) + (MainForm.enemyList[i].location.Y - this.location.Y) * (MainForm.enemyList[i].location.Y - this.location.Y));
                if (distence <= this.radius * 20)
                {
                    if (MainForm.enemyList[i].location.Y - this.location.Y < 0)
                    {
                        this.faceingAngle = (float)((Math.Acos((MainForm.enemyList[i].location.X - this.location.X) / distence)) * (180f / Math.PI));
                    }
                    else if (MainForm.enemyList[i].location.Y - this.location.Y >= 0)
                    {
                        this.faceingAngle = -(float)((Math.Acos((MainForm.enemyList[i].location.X - this.location.X) / distence)) * (180f / Math.PI));
                    }
                    else
                    {
                        fireing = false;
                    }
                }
                
            }

        }
    }
}
