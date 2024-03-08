using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schach
{
    internal class Renderer
    {
        protected List<Texture2D> textures;

        public Renderer()
        {
            textures = [];
        }

        public Renderer(int count)
        {
            textures = new List<Texture2D>(count);
        }

        public Renderer(Texture2D[] textures)
        {
            this.textures = [.. textures]; 
        }

        public Renderer(List<Texture2D> textures)
        {
            this.textures = textures;
        }

        public Renderer(string[] texturePath)
        {
            textures = [];

            LoadTextures(texturePath);
        }

        public Renderer(List<string> texturePath)
        {
            textures = [];

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
            for(int i = 0; i < textures.Count; i++)
            {
                Raylib.DrawTexture(textures[i], 0, 0, Color.White);
            }
        }
    }
}
