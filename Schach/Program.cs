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

            while (!Raylib.WindowShouldClose())
            {
                Vector2i mouseCoord = mouse.GetBoardCoords(renderer);

                Raylib.BeginTextureMode(renderer.WindowCanvas);

                Raylib.ClearBackground(Color.White);
                renderer.Render(board);

                Raylib.EndTextureMode();
                

                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.Black);
                renderer.RenderScalable();

                Raylib.EndDrawing();

                if(mouse.IsMouseClicked())
                {
                    var not = SchachCore.ConvertToStringChessPos(mouseCoord.X, mouseCoord.Y);
                    

                    SchachCore.Print($"{(char)(not >> 8)}{(char)(not & 255)}");
                }
            }

            Raylib.CloseWindow();
        }
    }
}

