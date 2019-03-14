using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Utilities
{
    public class Rectangle
    {
        public Point Position { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public double Left
        {
            get
            {
                return Position.X;
            }
        }

        public double Right
        {
            get
            {
                return Position.X + Width;
            }
        }

        public double Top
        {
            get
            {
                return Position.Y;
            }
        }

        public double Bottom
        {
            get
            {
                return Position.Y + Height;
            }
        }

        public Rectangle(Point position, double width, double height)
        {
            Position = position;
            Width = width;
            Height = height;
        }

        public bool Intersects(Rectangle other)
        {
            if (Right >= other.Left && Bottom >= other.Top && Left <= other.Right && Top <= other.Bottom)
            {
                return true;
            }
            return false;
        }

        public bool Contains(Point point)
        {
            if (Left <= point.X && Right >= point.X && Top <= point.Y && Bottom >= point.Y)
            {
                return true;
            }
            return false;
        }
    }
}
