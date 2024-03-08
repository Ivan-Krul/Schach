using Raylib_cs;
using Schach;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schach
{
    internal class RendererBoard : Renderer
    {
        int offset = 50;

        public RendererBoard() : base(13) => SetDefaultTexture();

        public RendererBoard(int offset) : base(13)
        {
            this.offset = offset;
            SetDefaultTexture();
        }

        protected void SetDefaultTexture()
        {
            string[] paths =
            {
                "./assets/board.png",
                "./assets/blackKing.png",
                "./assets/blackQueen.png",
                "./assets/blackBishop.png",
                "./assets/blackKnight.png",
                "./assets/blackRook.png",
                "./assets/blackPawn.png",
                "./assets/whiteKing.png",
                "./assets/whiteQueen.png",
                "./assets/whiteBishop.png",
                "./assets/whiteKnight.png",
                "./assets/whiteRook.png",
                "./assets/whitePawn.png"
            };
            LoadTextures(paths);
        }

        protected Texture2D? PickTexture(SchachCore.Piece piece)
        {
            var color = piece.GetColor();
            var type = piece.GetPieceType();

            if(color < 1)
                return null;

            return textures[(color - 1) * 6 + ((int)type)];
        }

        public void Render(SchachCore.Board board)
        {
            var state = board.state;

            Raylib.DrawTexture(textures[0], 0, 0, Raylib_cs.Color.White);

            for(int i = 0; i < state.Length; i++)
            {
                var texture = PickTexture(state[i]);
                var coordX = i & 0b111;
                var coordY = i >> 3;

                if(texture.HasValue)
                {
                    Raylib.DrawTexture(texture.Value, coordX * offset + offset, coordY * offset + offset, Raylib_cs.Color.White);
                }
            }
        }
    }
}
