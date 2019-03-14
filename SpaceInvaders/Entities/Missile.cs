using SpaceInvaders.Models;
using SpaceInvaders.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Entities
{
    public class Missile : Entity
    {
        const double MISSILE_WIDTH = 2;
        const double MISSILE_HEIGHT = 16;

        const int MISSILE_SPEED = 360;
        const string MISSILE_SPRITE = "ms-appx:///Assets/Missile.png";
        public const string MISSILE_TAG = "Missile";

        public Missile(Point position) : base(position, MISSILE_WIDTH, MISSILE_HEIGHT, MISSILE_SPRITE, MISSILE_TAG) { }

        public override void Update(double delta)
        {
            Position.Y += MISSILE_SPEED * delta;
            if (Position.Y > GameModel.CANVAS_HEIGHT)
            {
                Alive = false;
            }
        }
    }
}
