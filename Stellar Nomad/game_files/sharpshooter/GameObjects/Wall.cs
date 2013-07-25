using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace sharpshooter
{
    public class Wall
    {
        public int top;
        public int left;
        public int width;
        public int height;
        Bitmap image;

        public Wall(String color, int left, int top, int width, int height)
        {
            this.left = left;
            this.top = top;
            this.width = width;
            this.height = height;

            MainForm.wallList.Add(this);
            image = new Bitmap("Images/" + color + "Box.png");
        }

        public void Draw(Graphics g)
        {
            g.Transform = new Matrix();
            g.DrawImage(image, new RectangleF(left - MainForm.veiwOffSet.X, top - MainForm.veiwOffSet.Y, width, height));
        }

        public PointF pointNearestTo(PointF p)
        {
            PointF nearestPoint = new PointF();
            if (this.left > p.X)
            {
                nearestPoint.X = this.left;
            }
            else if (this.left + this.width < p.X)
            {
                nearestPoint.X = this.left + this.width;
            }
            else
            {
                nearestPoint.X = p.X;
            }

            if (this.top > p.Y)
            {
                nearestPoint.Y = this.top;
            }
            else if (this.top + this.height < p.Y)
            {
                nearestPoint.Y = this.top + this.height;
            }
            else
            {
                nearestPoint.Y = p.Y;
            }
            return(nearestPoint);
        }

        public PointF normalAtNearestPoint(PointF p)
        {
            PointF nearestPoint = this.pointNearestTo(p);
            PointF normal = new PointF();
            normal.X = p.X - nearestPoint.X;
            normal.Y = p.Y - nearestPoint.Y;
            if(normal.X == 0 && normal.Y == 0)
            {
                return(normal);
            }
            float factor = 1f / (float)Math.Sqrt((normal.X * normal.X) + (normal.Y * normal.Y));
            normal.X *= factor;
            normal.Y *= factor;
            return normal;
        }
        


    }
}
