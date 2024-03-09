using Schach;
using Raylib_cs;
using System.Numerics;
using static System.Formats.Asn1.AsnWriter;

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

            Raylib.SetConfigFlags(flags: ConfigFlags.ResizableWindow | ConfigFlags.VSyncHint);
            Raylib.InitWindow(500, 500, "Schach");

            var renderer = new RendererBoard();
            var mouse = new MouseInput();
            var mouseCoord = new Vector2();

            while (!Raylib.WindowShouldClose())
            {
                mouseCoord = mouse.GetVirtualMouse(renderer);

                Raylib.BeginTextureMode(renderer.WindowCanvas);

                Raylib.ClearBackground(Color.White);
                renderer.Render(board);

                Raylib.EndTextureMode();
                

                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.Black);
                renderer.RenderScalable();

                Raylib.EndDrawing();

                SchachCore.Print($"{(int)mouseCoord.X} {(int)mouseCoord.Y}");
            }

            Raylib.CloseWindow();
        }
    }
}

