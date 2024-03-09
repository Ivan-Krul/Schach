using Raylib_cs;
using Schach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Schach
{
    internal class MouseInput
    {
        protected Vector2 position;

        public MouseInput()
        {
            position = new Vector2();
        }

        public Vector2 GetVirtualMouse(Renderer renderer)
        {
            position = Raylib.GetMousePosition();
            var scale = renderer.GetScale();
            var texture = renderer.WindowCanvas.Texture;

            var actualPosition = new Vector2();
            actualPosition.X = (position.X - (Raylib.GetScreenWidth() - (texture.Width * scale)) * 0.5f) / scale;
            actualPosition.Y = (position.Y - (Raylib.GetScreenHeight() - (texture.Height * scale)) * 0.5f) / scale;

            return Raymath.Vector2Clamp(actualPosition, new Vector2(0,0), new Vector2(texture.Width, texture.Height));
        }


        public Vector2i GetBoardCoords(RendererBoard renderer)
        {
            var mouse = GetVirtualMouse(renderer);

            int mouseY = (int)mouse.Y / (renderer.Offset) - 1;
            int mouseX = (int)mouse.X / (renderer.Offset) - 1;

            mouseX = Math.Min(Math.Max(mouseX, 0), 7);
            mouseY = Math.Min(Math.Max(mouseY, 0), 7);

            return new Vector2i(mouseX, mouseY);
        }

        public bool IsMouseClicked()
        {
            return Raylib.IsMouseButtonPressed(MouseButton.Left);
        }
    }
}
