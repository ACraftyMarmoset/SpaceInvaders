using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpaceInvaders.Utilities;

namespace SpaceInvaders.Entities
{
    public class Enemy : Entity
    {
        public enum EnemyType { A, B, C };
        static string[] Sprites = { "ms-appx:///Assets/InvaderA1.png",
                                    "ms-appx:///Assets/InvaderB1.png",
                                    "ms-appx:///Assets/InvaderC1.png" };

        public double Speed { get; set; }
        public int FireRate { get; set; }

        public Enemy(Point location, EnemyType type, double speed, int fireRate) : base(location, Sprites[(int) type])
        {
            Speed = speed;
            FireRate = fireRate;
        }

        public override void Update(double delta)
        {

        }
    }
}
