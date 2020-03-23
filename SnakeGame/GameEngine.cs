using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SnakeGame
{
    public class GameEngine
    {
        private Random Random { get; set; }

        private Snake Snake { get; set; }

        private Apple currentApple { get; set; }

        public GameEngine()
        {
            this.Snake = new Snake();
            this.currentApple = GenerateApple();
        }

        public void Start()
        {
            Console.CursorVisible = false;

            PrintSnake();

            var direction = Console.ReadKey(true);

            do
            {
                if (Console.KeyAvailable)
                {
                    var newKey = Console.ReadKey(true);
                    //AreDirectionsOpposite(direction, newKey)
                    direction = AreDirectionsOpposite(direction, newKey) ? direction : newKey;
                }
                var coordinates = GetCoordinates(direction);

                SnakeMovement(coordinates);

                Thread.Sleep(100);
            } while (true);

        }

        private bool AreDirectionsOpposite(ConsoleKeyInfo direction, ConsoleKeyInfo newKey)
        {
            if (newKey.Key == ConsoleKey.LeftArrow && direction.Key == ConsoleKey.RightArrow ||
                newKey.Key == ConsoleKey.UpArrow && direction.Key == ConsoleKey.DownArrow ||
                newKey.Key == ConsoleKey.DownArrow && direction.Key == ConsoleKey.UpArrow ||
                newKey.Key == ConsoleKey.RightArrow && direction.Key == ConsoleKey.LeftArrow)
            {
                return true;
            }

            return false;
        }

        private void SnakeMovement(Coordinates newCoordinates)
        {
            Coordinates newSnakeHeadPosition = newCoordinates;
            Coordinates snakeElementToRemove = Snake.Body[0];
            Snake.Body.Remove(snakeElementToRemove);
            Snake.Body.Add(newSnakeHeadPosition);

            PrintSnake();

            Console.SetCursorPosition(snakeElementToRemove.X, snakeElementToRemove.Y);
            Console.Write(" ");

            if (currentApple.X == Snake.Body[Snake.Body.Count - 1].X && currentApple.Y == Snake.Body[Snake.Body.Count - 1].Y)
            {
                Snake.Body.Add(newCoordinates);
                currentApple = GenerateApple();
            }
        }

        private Coordinates GetCoordinates(ConsoleKeyInfo direction)
        {
            Coordinates coordinates = null;

            if (direction.Key == ConsoleKey.RightArrow)
            {
                coordinates = new Coordinates(Snake.Body[Snake.Body.Count - 1].X + 1, Snake.Body[Snake.Body.Count - 1].Y);
            }
            else if (direction.Key == ConsoleKey.LeftArrow)
            {
                coordinates = new Coordinates(Snake.Body[Snake.Body.Count - 1].X - 1, Snake.Body[Snake.Body.Count - 1].Y);
            }
            else if (direction.Key == ConsoleKey.UpArrow)
            {
                coordinates = new Coordinates(Snake.Body[Snake.Body.Count - 1].X, Snake.Body[Snake.Body.Count - 1].Y - 1);
            }
            else if (direction.Key == ConsoleKey.DownArrow)
            {
                coordinates = new Coordinates(Snake.Body[Snake.Body.Count - 1].X, Snake.Body[Snake.Body.Count - 1].Y + 1);
            }

            return coordinates;
        }

        private void PrintSnake()
        {
            foreach (var element in Snake.Body)
            {
                Console.SetCursorPosition(element.X, element.Y);
                Console.Write("#");
            }
        }

        private Apple GenerateApple()
        {
            this.Random = new Random();
            Apple currentApple = new Apple(Random.Next(0, Console.WindowWidth), Random.Next(0, Console.WindowHeight));
            currentApple.Display();

            return currentApple;
        }
    }
}
