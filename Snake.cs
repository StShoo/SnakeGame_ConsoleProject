using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_consoleGameProject
{
    internal class Snake
    {
        private readonly ConsoleColor _bodyColor;
        private readonly ConsoleColor _headColor;
        public Pixel Head { get; private set; }
        public Queue<Pixel> Body { get;} = new Queue<Pixel>();

        public Snake(int initialX, int initialY, ConsoleColor bodyColor, ConsoleColor headColor, int bodyLen = 3)
        {
            _bodyColor = bodyColor;
            _headColor = headColor;

            Head = new Pixel(initialX, initialY, _headColor);

            for(int i = bodyLen; i >= 0; i--)
            {
                Body.Enqueue(new Pixel(Head.X - i - 1, initialY, _bodyColor));
            }

            Draw();
        }

        public void Move(Direction direction) 
        {
            Clear();

            Body.Enqueue(new Pixel(Head.X, Head.Y, _bodyColor));
            Body.Dequeue();

            Head = direction switch
            {
                Direction.Right => new Pixel(Head.X + 1, Head.Y, _headColor),
                Direction.Left => new Pixel(Head.X - 1, Head.Y, _headColor),
                Direction.Up => new Pixel(Head.X, Head.Y - 1, _headColor),
                Direction.Down => new Pixel(Head.X, Head.Y + 1, _headColor),
                _ => Head
            };

            Draw();
        }

        public void Draw()
        {
            Head.Draw();

            foreach (Pixel pixel in Body)
            {
                pixel.Draw();
            }
        }

        public void Clear()
        {
            Head.Clear();

            foreach (Pixel pixel in Body)
            {
                pixel.Clear();
            }
        }
    }
}
