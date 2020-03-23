using System;

namespace SnakeGame
{
    public class GameConfiguration
    {
        public static int gameSpeed = 100;

        public static void ConfigureGame()
        {
            Console.CursorVisible = false;
        }
    }
}
