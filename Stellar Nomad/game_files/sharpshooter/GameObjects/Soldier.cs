using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace sharpshooter
{
    
    public class Soldier
    {
        public Picture pic;
        public PointF location;
        public float faceingAngle = 0;
        public PointF velocity;
        public int moveSpeed = 20;
        public Boolean fireing = false;
        public int radius;
        public int HP = 5;
        public Boolean killed = false;
        public Boolean hitFlicker = false;
        public int hitFlickerCount = 0;
        public Wepon currentWepon;
        public Wepon autoGunSlot;
        public Boolean isAutoGunner = false;
        public int startHP = 25;
        public Boolean isNPC = true;
        public Boolean onPlatform = false;
        public int gravity = MainForm.checkConfig("gravity");
        public Boolean isInverted = false;
        public int picFrames = 1;
        public int jumpBoost = MainForm.checkConfig("jump boost");
        public int fallSpeed = MainForm.checkConfig("max fall speed");
        public Point blockLocation;


        public Soldier(String Image, PointF location)
        {
            pic = new Picture(Image, location, picFrames, 60);
            velocity = new PointF();
            this.location = location;
            radius = pic.bitmap.Width / 2;
        }
        
        public void Draw(Graphics g)
        {
            if (this.killed)
            {
                return;
            }
            pic.angle = faceingAngle;
            if (!hitFlicker)
            {
                pic.location.X = location.X - MainForm.veiwOffSet.X;
                pic.location.Y = location.Y - MainForm.veiwOffSet.Y;
                pic.Draw(g);
                currentWepon.Draw(g);
            }
        }

        public virtual void Update(int time)
        {
            if (HP <= 0)
            {
                killed = true;
                Explosion e = new Explosion(this.location);
                MainForm.sound.playSound("Sounds/Explosion.wav", this.location);
                return;
            }
            if (hitFlickerCount > 0)
            {
                hitFlickerCount--;
                hitFlicker = !hitFlicker;
            }
            else
            {
                hitFlicker = false;
            }

            //old movement system, possable use for wepon movment
            //faceingAngle += (float)(time) * turnDir;
            //velocity.X = (float)Math.Cos(faceingAngle / 180f * Math.PI) * walkDir * moveSpeed;
            //velocity.Y = -(float)Math.Sin(faceingAngle / 180f * Math.PI) * walkDir * moveSpeed;
            
            if (fireing == true)
            {
                currentWepon.fire(this);

                if (!this.currentWepon.isAutoGun || isAutoGunner == true)
                {
                    currentWepon.fire(this);
                }
            }

            blockLocation.X = (int)location.X / MainForm.blockSize;
            blockLocation.Y = (int)location.Y / MainForm.blockSize;

            location.X = Math.Max(0, Math.Min((Level.mapBlockWidth - 1) * MainForm.blockSize, location.X));
            location.Y = Math.Max(0, Math.Min((Level.mapBlockHeight - 1) * MainForm.blockSize, location.Y));

            String blockBeneath = MainForm.levelMap[blockLocation.Y + 1].Substring(blockLocation.X, 1); //checks map aray for a block below soldier
            if (blockBeneath.Equals("1")
                && location.Y + (pic.bitmap.Height / 2) >= (blockLocation.Y + 1) * MainForm.blockSize) // compares soldier bottom to block top
                onPlatform = true;
            else onPlatform = false;


            if (onPlatform)
            {
                velocity.Y = 0;
            }
            else
            {
                if (velocity.Y < fallSpeed) //max fall speed of gravity
                {
                    velocity.Y += gravity; //force of gravity
                }
            }
            move();

            /*foreach (Wall w in MainForm.wallList)
            {
                PointF touchPoint = new PointF();
                if (this.isTouchingWall(w, ref touchPoint))
                {
                    pushFrom(touchPoint);
                    onPlatform = true;
                    if (this.isNPC)
                    {
                        //make stop
                    }
                }
                else onPlatform = false;
            }*/
            if (velocity.X != 0 && velocity.Y != 0)
            {
                pic.Update(time);
            }
            updateWepon(time);
        }

        public void move()
        {
            location.X += velocity.X;
            location.Y += velocity.Y;
        }

        public void moveLeft(Boolean status)
        {
            if (status) velocity.X = - moveSpeed;
            else velocity.X = 0;
            if (!isInverted)
            {
                pic.invert = true;
                isInverted = true;
            }
        }
        public void moveRight(Boolean status)
        {
            if (status) velocity.X = moveSpeed;
            else velocity.X = 0;
            if (isInverted)
            {
                pic.invert = true;
                isInverted = false;
            }
        }
        public void jump(Boolean status)
        {
            if (status)
            {
                velocity.Y = - jumpBoost;
            }
            else
            {

            }
        }

        public void takeDamage(int damage)
        {
            HP -= damage;
            hitFlickerCount = 4;
        }

        public bool isTouchingWall(Wall w, ref PointF touchPoint)
        {
            PointF nearestPoint = w.pointNearestTo(this.location);
            float distance = (float)Math.Sqrt((nearestPoint.X - this.location.X) * (nearestPoint.X - this.location.X) + (nearestPoint.Y - this.location.Y) * (nearestPoint.Y - this.location.Y));
            if(distance < this.radius)
            {
                touchPoint = nearestPoint;
                return (true);
            }
            else
            {
                return false;
            }
        }

        public void pushFrom(PointF p)
        {
            float actualDistance = (float)Math.Sqrt((p.X - this.location.X) * (p.X - this.location.X) + (p.Y - this.location.Y) * (p.Y - this.location.Y));
            if (actualDistance == 0)
            {
                return;
            }
            float pushDistence = this.radius + 1;
            float ratio = pushDistence / actualDistance;
            PointF move = new PointF(this.location.X - p.X, this.location.Y - p.Y);
            move.X *= ratio;
            move.Y *= ratio;
            this.location.X = p.X + move.X;
            this.location.Y = p.Y + move.Y;
        }

        public void updateWepon(int time)
        {
            float XOffset = (float)Math.Cos(this.faceingAngle / 180f * Math.PI) * 50f;
            float YOffset = -(float)Math.Sin(this.faceingAngle / 180f * Math.PI) * 50f;

            currentWepon.location.X = location.X + XOffset;
            currentWepon.location.Y = location.Y + YOffset;

            currentWepon.faceingAngle = this.faceingAngle;

            currentWepon.Update(time);
        }
    }
}