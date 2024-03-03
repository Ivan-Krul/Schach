using Schach;
using Raylib_cs;

namespace Schach
{
    class Program
    {
        public static void Main()
        {
            SchachCore.Print("Hi!");

            var board = SchachCore.CreateBoard();

            for (int i = 0; i < board.state.Length; i++)
            {
                SchachCore.Print(board.state[i].GetPieceType().ToString() + " " + board.state[i].GetColor().ToString());
            }

            string[] texPaths = { "./assets/board.png" };
            var renderer = new Renderer(texturePath: texPaths);

            Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
            Raylib.InitWindow(640, 360, "Schach");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                renderer.Render();

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}

