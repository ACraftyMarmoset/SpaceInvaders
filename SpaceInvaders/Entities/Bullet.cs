using SpaceInvaders.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Entities
{
    public class Bullet : Entity
    {
        const int BULLET_SPEED = 180;
        const string BULLET_SPRITE = "ms-appx:///Assets/Bullet.png";

        public Bullet(Point position) : base(position, BULLET_SPRITE) { }

        public override void Update(double delta)
        {
            Position.Y -= BULLET_SPEED * delta;
        }
    }
}
