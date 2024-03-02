using Schach;
using Raylib_cs;

namespace Schach
{
    class Program
    {
        public static void Main()
        {
            Import.Print("Hi!");

            var board = Import.CreateBoard();

            for (int i = 0; i < board.state.Length; i++)
            {
                Import.Print(board.state[i].ToString());
            }

            Raylib.InitWindow(640, 360, "Schach");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                Raylib.DrawText("Hello, world!", 12, 12, 20, Color.Black);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}

