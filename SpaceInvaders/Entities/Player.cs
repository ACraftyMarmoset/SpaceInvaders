using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

using SpaceInvaders.Utilities;
using Windows.UI.Xaml.Input;
using Windows.System;
using System.Diagnostics;
using Windows.UI.Core;

namespace SpaceInvaders.Entities
{
    public class Player : Entity
    {
        const int PLAYER_SPEED = 128;
        const double PLAYER_COOLDOWN = 1;
        const string PLAYER_SPRITE = "ms-appx:///Assets/Ship.png";
        const VirtualKey PLAYER_KEY_LEFT = VirtualKey.Left;
        const VirtualKey PLAYER_KEY_RIGHT = VirtualKey.Right;
        const VirtualKey PLAYER_KEY_SHOOT = VirtualKey.Space;

        public int Health { get; set; } = 3;
        public string HealthString
        {
            get
            {
                return new string('❤', Health);
            }
        }

        private bool MoveLeft { get; set; } = false;
        private bool MoveRight { get; set; } = false;
        private double Cooldown { get; set; } = 0;

        public Player(Point position) : base(position, PLAYER_SPRITE) { }

        public override void Update(double delta)
        {
            Cooldown -= delta;

            int direction;
            if ((MoveLeft && MoveRight) || (!MoveLeft && !MoveRight))
            {
                direction = 0;
            }
            else
            {
                direction = MoveRight ? 1 : -1;
            }
            Position.X += PLAYER_SPEED * direction * delta;
        }

        public void HandleInput(CoreWindow coreWindow)
        {
            MoveLeft = coreWindow.GetKeyState(PLAYER_KEY_LEFT).HasFlag(CoreVirtualKeyStates.Down);
            MoveRight = coreWindow.GetKeyState(PLAYER_KEY_RIGHT).HasFlag(CoreVirtualKeyStates.Down);

            if (Cooldown <= 0 && coreWindow.GetKeyState(PLAYER_KEY_SHOOT).HasFlag(CoreVirtualKeyStates.Down))
            {
                Game.Model.AddEntity(new Bullet(new Point(Position.X, Position.Y)));
                Cooldown = PLAYER_COOLDOWN;
            }
        }
    }
}
