using System.Diagnostics;
using static System.Console;
namespace Snake_consoleGameProject
{
    internal class Program
    {
        private const int MapWidth = 30;
        private const int MapHeight = 20;

        private const int ScreenWidth = MapWidth * 3;
        private const int ScreenHeight = MapHeight * 3;

        private const ConsoleColor borderColor = ConsoleColor.Gray;
        private const ConsoleColor headColor = ConsoleColor.DarkGreen;
        private const ConsoleColor bodyColor = ConsoleColor.Green;

        private const int FrameMs = 200;

        static void Main()
        {
            SetWindowSize(ScreenWidth, ScreenHeight);
            SetBufferSize(ScreenWidth, ScreenHeight);

            CursorVisible = false;

            DrawBorder();

            var snake = new Snake(10, 5, bodyColor, headColor);

            Direction currentMovement = Direction.Right;
            Stopwatch sw = new Stopwatch();

            while (true)
            {
                sw.Restart();

                while(sw.ElapsedMilliseconds < FrameMs)
                {
                    currentMovement = ReadMovement(currentMovement);
                }

                snake.Move(currentMovement);
            }
        }

        static Direction ReadMovement(Direction currentDirection)
        {
            if(!KeyAvailable)
            {
                return currentDirection;
            }

            ConsoleKey key = ReadKey(true).Key;

            currentDirection = key switch
            {
                ConsoleKey.UpArrow when currentDirection != Direction.Down => Direction.Up,
                ConsoleKey.DownArrow when currentDirection != Direction.Up => Direction.Down,
                ConsoleKey.LeftArrow when currentDirection != Direction.Right => Direction.Left,
                ConsoleKey.RightArrow when currentDirection != Direction.Left => Direction.Right,
                _ => currentDirection
            };

            return currentDirection;
        }

        static void DrawBorder()
        {
            for(int i = 0; i < MapWidth; i++)
            {
                new Pixel(i, 0, borderColor).Draw();
                new Pixel(i, MapHeight - 1, borderColor).Draw();
            }

            for (int i = 0; i < MapHeight; i++)
            {
                new Pixel(0, i, borderColor).Draw();
                new Pixel(MapWidth - 1, i, borderColor).Draw();
            }
        }
    }
}