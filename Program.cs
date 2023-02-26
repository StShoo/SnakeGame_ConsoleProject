using static System.Console;
namespace Snake_consoleGameProject
{
    internal class Program
    {
        private const int MapWidth = 30;
        private const int MapHeight = 20;
        private const ConsoleColor borderColor = ConsoleColor.Gray;

        static void Main()
        {
            SetWindowSize(MapWidth, MapHeight);
            SetBufferSize(MapWidth, MapHeight);
            CursorVisible = false;

            DrawBorder();

            ReadKey();
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