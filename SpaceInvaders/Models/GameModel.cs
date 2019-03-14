using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpaceInvaders.Entities;
using SpaceInvaders.Utilities;

namespace SpaceInvaders.Models
{
    public class GameModel
    {
        const double PLAYER_START_X = 2;
        const double PLAYER_START_Y = 6;
        const double ENEMY_SPEED_BASE = 30;
        const int ENEMY_ROWS = 8;
        const int ENEMY_COLUMNS = 12;
        const int ENEMY_COLUMN_LIMIT = 8;
        const int MIN_ENEMIES = 1;
        const int MAX_ENEMIES = 24;

        public double GameWidth { get; set; }
        public double GameHeight { get; set; }

        public Player PlayerCharacter { get; set; }
        public List<Entity> Entities { get; set; } = new List<Entity>();
        public int Difficulty = 4;
        public int Score { get; set; } = 0;

        public GameModel(double gameWidth, double gameHeight)
        {
            GameWidth = gameWidth;
            GameHeight = gameHeight;
            PlayerCharacter = new Player(new Point(GameWidth / PLAYER_START_X, GameHeight - GameHeight / PLAYER_START_Y));
            Entities.Add(PlayerCharacter);
            GenerateLevel(Difficulty);
        }

        public void GenerateLevel(int difficulty)
        {
            int enemies = Clamp(difficulty * ENEMY_COLUMNS, 1, 24);
            double x = GameWidth / (ENEMY_COLUMNS * 4), y = GameHeight / ENEMY_ROWS;
            for (int i = 0; i < enemies; i++, x += GameWidth / ENEMY_COLUMNS)
            {
                if (i > 0 && i % ENEMY_COLUMN_LIMIT == 0)
                {
                    x = GameWidth / (ENEMY_COLUMNS * 4);
                    y += GameHeight / ENEMY_ROWS;
                }
                var sprite_values = Enum.GetValues(typeof(Enemy.EnemyType));
                var sprite = Game.Rng.Next(sprite_values.Length);
                Entities.Add(new Enemy(new Point(x, y), (Enemy.EnemyType) sprite, ENEMY_SPEED_BASE * (difficulty + 1), difficulty));
            }
            foreach (var entity in Entities)
            {
                Debug.WriteLine($"Entity: {entity} ({entity.Position.X}, {entity.Position.Y})");
            }
        }

        public void AddEntity(Entity entity)
        {
            Entities.Add(entity);
        }

        public int Clamp(int value, int min, int max)
        {
            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }
            return value;
        }
    }
}
