using static System.Console;
namespace Snake_consoleGameProject
{
    internal class Program
    {
        private const int MapWidth = 30;
        private const int MapHeight = 20;
        static void Main()
        {
            SetWindowSize(MapWidth, MapHeight);
            SetBufferSize(MapWidth, MapHeight);
            CursorVisible = false;

            ReadKey();
        }
    }
}