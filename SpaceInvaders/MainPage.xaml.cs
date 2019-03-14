using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using SpaceInvaders.Models;
using System.Diagnostics;
using Windows.UI.Xaml.Media.Imaging;

namespace SpaceInvaders
{
    public sealed partial class Game : Page
    {
        public double GameWidth { get; set; }
        public double GameHeight { get; set; }

        public static GameModel Model;
        public Stopwatch Timer = Stopwatch.StartNew();
        public double Delta;

        public static Random Rng { get; } = new Random();

        public Game()
        {
            InitializeComponent();
        }

        public void MainLoop(object sender, object args)
        {
            HandleInput();
            Update();
            Render();
        }

        public void HandleInput()
        {
            Model.PlayerCharacter.HandleInput(Window.Current.CoreWindow);
        }

        public void Update()
        {
            Delta = Timer.Elapsed.TotalSeconds;
            Timer.Restart();

            foreach (var entity in Model.Entities)
            {
                entity.Update(Delta);
            }
            Render();
        }

        public void Render()
        {
            foreach (var entity in Model.Entities)
            {
                if (!GameBoard.Children.Contains(entity.Sprite))
                {
                    GameBoard.Children.Add(entity.Sprite);
                }

                Canvas.SetLeft(entity.Sprite, entity.Position.X);
                Canvas.SetTop(entity.Sprite, entity.Position.Y);
            }
        }

        private void GameBoard_Loaded(object sender, RoutedEventArgs e)
        {
            GameWidth = GameBoard.ActualWidth;
            GameHeight = GameBoard.ActualHeight;

            Model = new GameModel(GameWidth, GameHeight);
            DataContext = Model;
            
            CompositionTarget.Rendering += MainLoop;
        }
    }
}
