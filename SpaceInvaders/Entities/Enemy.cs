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
        const double ENEMY_WIDTH = 40;
        const double ENEMY_HEIGHT = 30;
        public const string ENEMY_TAG = "Enemy";
        const int ENEMY_A_SCORE = 50;
        const int ENEMY_B_SCORE = 100;
        const int ENEMY_C_SCORE = 200;

        public enum EnemyEnum { A, B, C };
        static string[] Sprites = { "ms-appx:///Assets/InvaderA1.png",
                                    "ms-appx:///Assets/InvaderB1.png",
                                    "ms-appx:///Assets/InvaderC1.png" };

        public EnemyEnum EnemyType { get; }
        public double Speed { get; set; }
        public int FireRate { get; set; }
        public int ScoreValue
        {
            get
            {
                switch (EnemyType)
                {
                    case EnemyEnum.A:
                        return ENEMY_A_SCORE;
                    case EnemyEnum.B:
                        return ENEMY_B_SCORE;
                    case EnemyEnum.C:
                        return ENEMY_C_SCORE;
                    default:
                        return 0;
                }
            }
        }

        public Enemy(Point location, EnemyEnum type, double speed, int fireRate) : base(location, ENEMY_WIDTH, ENEMY_HEIGHT, 
                                                                                        Sprites[(int) type], ENEMY_TAG)
        {
            EnemyType = type;
            Speed = speed;
            FireRate = fireRate;
        }

        public override void Update(double delta)
        {
            Position.X += (Game.Rng.Next(2) == 1 ? 1 : -1) * Speed * delta;
            Position.Y += (Game.Rng.Next(2) == 1 ? 1 : -1) * Speed * delta;

            if (Game.Rng.NextDouble() < FireRate * delta / 100)
            {
                Game.Model.AddEntity(new Missile(new Point(Position.X + Width / 2, Position.Y + Height)));
            }
        }
    }
}
