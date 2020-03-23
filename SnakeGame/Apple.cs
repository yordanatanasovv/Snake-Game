using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class Apple : Coordinates
    {
        public Apple(int x, int y)
            : base(x, y)
        {
        }
    }

    public static class AppleExtension
    {
        public static void Display(this Apple apple)
        {
            Console.SetCursorPosition(apple.X, apple.Y);
            Console.Write("@");
        }
    }
}
