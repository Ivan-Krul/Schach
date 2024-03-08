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

            const int defaultWindowSizeX = 500;
            const int defaultWindowSizeY = 500;

            Raylib.SetConfigFlags(flags: ConfigFlags.ResizableWindow | ConfigFlags.VSyncHint);
            Raylib.InitWindow(defaultWindowSizeX, defaultWindowSizeY, "Schach");

            var windowSizeX = 500;
            var windowSizeY = 500;
            var windowCanvas = Raylib.LoadRenderTexture(windowSizeX, windowSizeY);

            Rectangle RectSRC = new Rectangle();
            Rectangle RectDST = new Rectangle();
            Vector2 Origin = new Vector2();

            var renderer = new RendererBoard();
            float scale = 0;


            while (!Raylib.WindowShouldClose())
            {
                scale = Math.Min(Raylib.GetScreenWidth() / (float)windowSizeX, Raylib.GetScreenHeight() / (float)windowSizeY);

                Raylib.BeginTextureMode(windowCanvas);

                Raylib.ClearBackground(Color.White);
                renderer.Render(board);

                Raylib.EndTextureMode();


                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.Black);

                RectSRC = new Rectangle(0.0f, 0.0f, (float)windowCanvas.Texture.Width, (float)-windowCanvas.Texture.Height);
                RectDST = new Rectangle((Raylib.GetScreenWidth() - ((float)windowSizeX * scale)) * 0.5f, (Raylib.GetScreenHeight() - ((float)windowSizeY * scale)) * 0.5f, (float)windowSizeX * scale, (float)windowSizeY * scale);

                Raylib.DrawTexturePro(
                    windowCanvas.Texture,
                    RectSRC,
                    RectDST,
                    new Vector2(0, 0),
                    0.0f,
                    Raylib_cs.Color.White);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}

