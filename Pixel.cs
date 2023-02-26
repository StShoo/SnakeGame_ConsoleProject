using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_consoleGameProject
{
    public readonly struct Pixel
    {
        public Pixel(int x, int y, ConsoleColor color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public int X { get; }
        public int Y { get; }
        public ConsoleColor Color { get; }
    }
}
