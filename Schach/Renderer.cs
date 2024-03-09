using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Schach
{
    internal class Renderer
    {
        protected List<Texture2D>   textures;
        private int                 windowSizeX = 500;
        private int                 windowSizeY = 500;
        public RenderTexture2D WindowCanvas { get; private set; }

        private Rectangle RectSRC = new Rectangle();
        private Rectangle RectDST = new Rectangle();

        private float scale = 0.0f;

        public Renderer()
        {
            textures = [];
        }

        public Renderer(int count)
        {
            textures = new List<Texture2D>(count);
            WindowCanvas = Raylib.LoadRenderTexture(windowSizeX, windowSizeY);
            RectSRC = new Rectangle(0.0f, 0.0f, WindowCanvas.Texture.Width, -WindowCanvas.Texture.Height);
        }

        public Renderer(Texture2D[] textures)
        {
            this.textures = [.. textures];
            WindowCanvas = Raylib.LoadRenderTexture(windowSizeX, windowSizeY);
            RectSRC = new Rectangle(0.0f, 0.0f, WindowCanvas.Texture.Width, -WindowCanvas.Texture.Height);
        }

        public Renderer(List<Texture2D> textures)
        {
            this.textures = textures;
            WindowCanvas = Raylib.LoadRenderTexture(windowSizeX, windowSizeY);
            RectSRC = new Rectangle(0.0f, 0.0f, WindowCanvas.Texture.Width, -WindowCanvas.Texture.Height);
        }

        public Renderer(string[] texturePath)
        {
            textures = [];
            WindowCanvas = Raylib.LoadRenderTexture(windowSizeX, windowSizeY);
            RectSRC = new Rectangle(0.0f, 0.0f, WindowCanvas.Texture.Width, -WindowCanvas.Texture.Height);

            LoadTextures(texturePath);
        }

        public Renderer(List<string> texturePath)
        {
            textures = [];
            WindowCanvas = Raylib.LoadRenderTexture(windowSizeX, windowSizeY);
            RectSRC = new Rectangle(0.0f, 0.0f, WindowCanvas.Texture.Width, -WindowCanvas.Texture.Height);

            LoadTextures([.. texturePath]);
        }

        public Renderer(int windowX, int windowY)
        {
            textures = [];
            windowSizeX = windowX;
            windowSizeY = windowY;
            WindowCanvas = Raylib.LoadRenderTexture(windowSizeX, windowSizeY);
            RectSRC = new Rectangle(0.0f, 0.0f, WindowCanvas.Texture.Width, -WindowCanvas.Texture.Height);
        }

        public Renderer(int count, int windowX, int windowY)
        {
            textures = new List<Texture2D>(count);
            windowSizeX = windowX;
            windowSizeY = windowY;
            WindowCanvas = Raylib.LoadRenderTexture(windowSizeX, windowSizeY);
            RectSRC = new Rectangle(0.0f, 0.0f, WindowCanvas.Texture.Width, -WindowCanvas.Texture.Height);
        }

        public Renderer(Texture2D[] textures, int windowX, int windowY)
        {
            this.textures = [.. textures];
            windowSizeX = windowX;
            windowSizeY = windowY;
            WindowCanvas = Raylib.LoadRenderTexture(windowSizeX, windowSizeY);
            RectSRC = new Rectangle(0.0f, 0.0f, WindowCanvas.Texture.Width, -WindowCanvas.Texture.Height);
        }

        public Renderer(List<Texture2D> textures, int windowX, int windowY)
        {
            this.textures = textures;
            windowSizeX = windowX;
            windowSizeY = windowY;
            WindowCanvas = Raylib.LoadRenderTexture(windowSizeX, windowSizeY);
            RectSRC = new Rectangle(0.0f, 0.0f, WindowCanvas.Texture.Width, -WindowCanvas.Texture.Height);
        }

        public Renderer(string[] texturePath, int windowX, int windowY)
        {
            textures = [];
            windowSizeX = windowX;
            windowSizeY = windowY;
            WindowCanvas = Raylib.LoadRenderTexture(windowSizeX, windowSizeY);
            RectSRC = new Rectangle(0.0f, 0.0f, WindowCanvas.Texture.Width, -WindowCanvas.Texture.Height);

            LoadTextures(texturePath);
        }

        public Renderer(List<string> texturePath, int windowX, int windowY)
        {
            textures = [];
            windowSizeX = windowX;
            windowSizeY = windowY;
            WindowCanvas = Raylib.LoadRenderTexture(windowSizeX, windowSizeY);
            RectSRC = new Rectangle(0.0f, 0.0f, WindowCanvas.Texture.Width, -WindowCanvas.Texture.Height);

            LoadTextures(texturePath.ToArray());
        }

        protected void LoadTextures(string[] texturePath)
        {
            for (int i = 0; i < texturePath.Length; i++)
            {
                textures.Add(Raylib.LoadTexture(texturePath[i]));
            }
        }

        virtual public void Render()
        {
            for (int i = 0; i < textures.Count; i++)
            {
                Raylib.DrawTexture(textures[i], 0, 0, Color.White);
            }
        }

        public float GetScale()
        {
            return scale = Math.Min(Raylib.GetScreenWidth() / (float)windowSizeX, Raylib.GetScreenHeight() / (float)windowSizeY);
        }

        public void RenderScalable()
        {
            RectDST = new Rectangle((Raylib.GetScreenWidth() - (windowSizeX * scale)) * 0.5f, (Raylib.GetScreenHeight() - (windowSizeY * scale)) * 0.5f, windowSizeX * scale, windowSizeY * scale);

            Raylib.DrawTexturePro(
                WindowCanvas.Texture,
                RectSRC,
                RectDST,
                new Vector2(0, 0),
                0.0f,
            Raylib_cs.Color.White);
        }
    }
}
