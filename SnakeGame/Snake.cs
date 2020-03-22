using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class Snake
    {
        public List<Coordinates> Body { get; set; }

        public Snake()
        {
            this.Body = new List<Coordinates> { new Coordinates(0, 0), new Coordinates(1, 0), new Coordinates(2, 0) };
        }
    }
}
