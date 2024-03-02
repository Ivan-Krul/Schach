using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Schach
{
    internal class ImportedStructs
    {
        public enum PieceType
        {
            none,
            king,
            queen,
            bishop,
            knight,
            rook,
            pawn,
            _count
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct Piece
        {
            [FieldOffset(0)]
            public byte data;

            [FieldOffset(0)]
            public PieceType type;

            [FieldOffset(0)]
            public byte color;

            public Piece(byte color, PieceType type)
            {
                this.data = 0;
                this.color = (byte)(color & 7);
                this.type = type;
            }
        }

        public class Board
        {
            public const int BOARD_SIDE = 8;
            public const int BOARD_AREA = BOARD_SIDE * BOARD_SIDE;

            public Piece[] state = new Piece[BOARD_AREA];
            public byte count_players;
            public byte move;

            public Board(byte count_players, byte move)
            {
                this.count_players = count_players;
                this.move = move;
            }
        }
    }
}
