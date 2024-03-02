using Schach;
using Raylib_cs;

namespace Schach
{
    class Program
    {
        public static void Main()
        {
            Import.Print("Hi!");

            // System.TypeLoadException: 'Cannot marshal field 'state' of type 'Board': This type can only be marshaled in restricted ways.'
            unsafe
            {
                var board = Import.CreateBoard();

                for (int i = 0; i < 64; i++)
                {
                    
                    Import.Print(((ImportedStructs.Board*)(board))->state[i].ToString());
                }

                Import.DeleteBoard(board);
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

