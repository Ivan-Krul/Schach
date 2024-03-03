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
            var piece = Import.GetPiece();

            Import.Print(piece.value.ToString());

            var arr = Import.GetArray5().a;

            for(int i = 0; i < arr.Length; i++)
            {
                Import.Print(arr[i].ToString() + " ");
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

