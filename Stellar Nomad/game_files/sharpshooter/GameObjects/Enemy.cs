using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace sharpshooter
{
    public class Enemy : Soldier
    {
        public Enemy(PointF location) : base("images/Enemy1.png", location)
        {
            MainForm.enemyList.Add(this);
            picFrames = 4;
            fireing = true;
            moveSpeed = 2;
            HP = 10;
            this.currentWepon = new EnemyPistol(this.location);
        }

        public override void Update(int time)
        {
            base.Update(time);
                //roaming
        }
    }
}
