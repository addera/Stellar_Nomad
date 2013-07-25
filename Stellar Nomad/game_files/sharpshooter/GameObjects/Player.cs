using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace sharpshooter
{
    public class Player : Soldier
    {

        public Player(PointF location) : base("images/player_image.png", location)
        {
            isNPC = false;
            HP = startHP;
            moveSpeed = MainForm.checkConfig("player move speed");
            picFrames = 1;
            this.currentWepon = new EnemyPistol(this.location);
        }

        public override void Update(int time)
        {
            base.Update(time);
        }

        public void KeyDown(Object Senders, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                moveLeft(true);
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                moveRight(true);
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                jump(true);
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                //crouch
            }
            if (e.KeyCode == Keys.Space)
            {
                fireing = true;
            }
            if (e.KeyCode == Keys.R)
            {
                Level.createLevel();
                killed = false;
            }
        }

        public void KeyUp(Object Senders, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                moveLeft(false);
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                moveRight(false);
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                jump(false);
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                //crouch
            }
            if (e.KeyCode == Keys.Space)
            {
                fireing = false;
            }
        }
    }
}
