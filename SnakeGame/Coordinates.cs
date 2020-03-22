using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class Coordinates
    {
        private int _x;
        private int _y;

        public Coordinates(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        public int X 
        {
            get
            {
                return this._x;
            }
            set
            {
                if (value < 0 || value >= Console.WindowWidth)
                {
                    throw new ArgumentOutOfRangeException($"Out of bouneries. X: {value}");
                }

                this._x = value;
            }
        }

        public int Y 
        {
            get
            {
                return this._y;
            }
            set
            {
                if (value < 0 || value >= Console.WindowHeight)
                {
                    throw new ArgumentOutOfRangeException($"Out of bouneries. Y: {value}");
                }

                this._y = value;
            }
        }
    }
}
