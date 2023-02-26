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
        private const ConsoleColor foodColor = ConsoleColor.DarkRed;

        private const int FrameMs = 200;

        private static readonly Random random = new Random();

        static void Main()
        {
            SetWindowSize(ScreenWidth, ScreenHeight);
            SetBufferSize(ScreenWidth, ScreenHeight);

            CursorVisible = false;

            while(true)
            {
                StartGame();
                Thread.Sleep(100);
                ReadKey();
                Console.Clear();
            }
        }

        static void StartGame()
        {
            DrawBorder();

            var snake = new Snake(10, 5, bodyColor, headColor);

            Pixel food = GenFood(snake);
            food.Draw();

            Direction currentMovement = Direction.Right;
            Stopwatch sw = new Stopwatch();

            int score = 0;

            while (true)
            {
                sw.Restart();

                Direction oldMovement = currentMovement;

                while (sw.ElapsedMilliseconds < FrameMs)
                {
                    if (oldMovement == currentMovement)
                    {
                        currentMovement = ReadMovement(currentMovement);
                    }
                }

                if(snake.Head.X == food.X && snake.Head.Y == food.Y)
                {
                    snake.Move(currentMovement, true);

                    food = GenFood(snake);
                    food.Draw();
                    score++;
                }
                else
                {
                    snake.Move(currentMovement);
                }

                if (snake.Head.X == MapWidth - 1
                    || snake.Head.X == 0
                    || snake.Head.Y == MapHeight - 1
                    || snake.Head.Y == 0
                    || snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y))
                    break;
            }

            snake.Clear();

            SetCursorPosition(ScreenWidth / 3, ScreenHeight / 2);
            WriteLine("Game over " +
                $"Score: {score}");
        }

        static Pixel GenFood(Snake snake)
        {
            Pixel food;

            do
            {
                food = new Pixel(random.Next(1, MapWidth - 2), random.Next(1, MapHeight - 2), foodColor);
            } while (snake.Head.X == food.X && snake.Head.Y == food.Y 
                    || snake.Body.Any(b => b.X == food.X && b.Y == food.Y));

            return food;
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