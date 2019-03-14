using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpaceInvaders.Utilities;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace SpaceInvaders.Entities
{
    public abstract class Entity
    {
        public Point Position { get; set; }
        public Image Sprite { get; set; }

        public Entity(Point position, string sprite)
        {
            Position = position;
            Sprite = new Image() { Source = new BitmapImage(new Uri(sprite)) };
        }

        public abstract void Update(double delta);
    }
}
