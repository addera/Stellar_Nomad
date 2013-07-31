using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace sharpshooter
{
    
    public class Picture
    {
        public Bitmap bitmap;
        public PointF location;
        public float angle = 0f;
        public PointF offSet;
        public int frame = 0;
        public int frameCount;
        public int timePerFrame = 0;
        public int animationCount = 0;
        public Boolean invert = false;

        public Picture(String Filename, PointF location, int frames, int flipTime)
        {
            this.frameCount = frames;
            this.timePerFrame = flipTime;
            bitmap = new Bitmap(Filename);
            this.location = location;
            offSet = new PointF(bitmap.Width / frameCount / 2f, bitmap.Height / frameCount / 2f);
            timePerFrame = 50;
        }

        public void Draw(Graphics g)
        {
            Point drawLocation = new Point((int)(location.X - offSet.X), (int)(location.Y - offSet.Y));
            Matrix m = new Matrix();
            m.RotateAt(-angle, location); // used to rotate
            if (invert)
            {
                bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                invert = false;
            }
            g.Transform = m;
            g.DrawImage(bitmap, 
                new Rectangle(drawLocation.X, drawLocation.Y, bitmap.Width, bitmap.Height / this.frameCount), 
                new Rectangle(0, bitmap.Height / this.frameCount * this.frame, bitmap.Width, bitmap.Height / this.frameCount), 
                GraphicsUnit.Pixel);
        }

        public void Update(int time)
        {
            animationCount += time;

            if (animationCount >= timePerFrame)
            {
                this.frame++;
                if (this.frame >= frameCount)
                {
                    this.frame = 0;
                }
                animationCount = 0;
            }
        }
    }
}
