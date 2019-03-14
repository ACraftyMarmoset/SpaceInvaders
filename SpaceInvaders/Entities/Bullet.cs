using SpaceInvaders.Models;
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
        const double BULLET_WIDTH = 2;
        const double BULLET_HEIGHT = 16;

        const int BULLET_SPEED = 360;
        const string BULLET_SPRITE = "ms-appx:///Assets/Bullet.png";
        public const string BULLET_TAG = "Bullet";

        public Bullet(Point position) : base(position, BULLET_WIDTH, BULLET_HEIGHT, BULLET_SPRITE, BULLET_TAG) { }

        public override void Update(double delta)
        {
            Position.Y -= BULLET_SPEED * delta;
            if (Position.Y < 0 - Height)
            {
                Alive = false;
            }
        }
    }
}
