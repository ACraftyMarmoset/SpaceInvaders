using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpaceInvaders.Utilities;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace SpaceInvaders.Entities
{
    public abstract class Entity
    {
        public Point Position { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle Hitbox { get; set; }
        public Image Sprite { get; set; }
        public bool Alive { get; set; } = true;
        public string Tag { get; set; } = "None";

        public Entity(Point position, double width, double height, string sprite, string tag)
        {
            Position = position;
            Sprite = new Image() { Source = new BitmapImage(new Uri(sprite)),
                                   Width = width, Height = height,
                                   Stretch = Stretch.Fill };

            Width = Sprite.Width;
            Height = Sprite.Height;
            Hitbox = new Rectangle(Position, Width, Height);

            Tag = tag;
        }

        public abstract void Update(double delta);
    }
}
